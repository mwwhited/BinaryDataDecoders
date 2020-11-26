using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Test1
{
    //http://home.mira.net/~gnb/gps/nmea.html
    //http://vancouver-webpages.com/peter/nmeafaq.txt

    public class Gprmc
    {
        private string[] _parts;
        /*
         * 0 = Command
         * 1 = Satellite Time [ HHMMSS.XXX ]
         * 2 = Fix Status [ (A)ctive | i(V)alid ]
         * 3 = Latitude Degrees [ HHMM.M ]
         * 4 = Latitude Hemisphere [ (S)outh | (N)orth ]
         * 5 = Longitude Degrees [ HHHMM.M ]
         * 6 = Longitude Hemisphere [ (W)est | (E)ast ]
         * 7 = Speed in knots
         * 8 = Bearing in azimuth
         * 9 = Satellite Date [ DDMMYY ] 
         * 10 = Magnetic variation (ignore)
         * 11 = Magnetic variation direction and Checksum
         */
        //$GPRMC,001021.000,A,3959.518,N  ▲,08246.785,W,0.1,0.0,180508,0.  ▲0,E*75

        public Gprmc(string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
                throw new ArgumentNullException("GPS Sentence must not be null or empty");

            if (!sentence.StartsWith("$GPRMC"))
                throw new ArgumentOutOfRangeException("GPS Sentence is not a $GPRMC command");

            if (!CheckGpsChecksum(sentence))
                throw new ArgumentException("GPS Sentence checksum failed");

            _sentence = sentence;
            _parts = _sentence.Split(",".ToCharArray());
        }
        
        private string _sentence;
        public string Sentence { get { return _sentence; } }

        private DateTime _dateTime = DateTime.MinValue;
        public DateTime SatelliteDateTime
        {
            get
            {
                if (_dateTime == DateTime.MinValue)
                {
                    int _hour = int.Parse(_parts[1].Substring(0, 2));
                    int _min = int.Parse(_parts[1].Substring(2, 2));
                    int _sec = int.Parse(_parts[1].Substring(4, 2));
                    int _mSec = int.Parse(_parts[1].Substring(7, 3));

                    int _day = int.Parse(_parts[9].Substring(0, 2));
                    int _month = int.Parse(_parts[9].Substring(2, 2));
                    int _year = 2000 + int.Parse(_parts[9].Substring(4, 2));

                    _dateTime = new DateTime(_year, _month, _day, _hour, _min, _sec, _mSec, DateTimeKind.Utc);
                }

                return _dateTime;
            }
        }

        private bool? _fixed;
        public bool SatelliteFix
        {
            get
            {
                if (_fixed == null)
                {
                    _fixed = _parts[2].StartsWith("A");
                }
                return _fixed.Value;
            }
        }

        private Degree _latitude;
        public Degree Latitude
        {
            get
            {
                if (_latitude == null)
                {
                    _latitude = new Degree(_parts[3], _parts[4]); 
                }
                return _latitude;
            }
        }

        private Degree _longitude;
        public Degree Longitude
        {
            get
            {
                if (_longitude == null)
                {
                    _longitude = new Degree(_parts[5], _parts[6]); 
                }
                return _longitude;
            }
        }

        private Bearing _bearing;
        public Bearing Bearing
        {
            get
            {
                if (_bearing == null)
                {
                    _bearing = new Bearing(_parts[8]);
                }
                return _bearing;
            }
        }

        private string _toString = null;
        public override string ToString()
        {
            if (string.IsNullOrEmpty(_toString))
            {
                _toString =
                    "GPRMC:" +
                    "\tValid: " + SatelliteFix.ToString() + "\r\n" + 
                    "\tUTC: " + SatelliteDateTime.ToUniversalTime().ToString() + "\r\n" +
                    "\tLocal: " + SatelliteDateTime.ToLocalTime().ToString() + "\r\n" +
                    "\tLatitude: " + Latitude.ToString() + "\r\n" +
                    "\tLongitude: " + Longitude.ToString() + "\r\n" + 
                    "\tHeading: " + Bearing.ToString() + "\r\n";
            }
            return _toString;
        }

        public static bool CheckGpsChecksum(string sentence)
        {
            var _recList = ASCIIEncoding.ASCII.GetBytes(sentence).Where(b => b > 43 && b < 91);
            int _len = _recList.Count();

            //int _checkValue = int.Parse(ASCIIEncoding.ASCII.GetString(_recList.Skip(_len - 2).Take(2).ToArray()), NumberStyles.HexNumber);

            var _checkList = _recList.Skip(_len - 2).Take(2).Select(s => ((s & 0x30) == 0x30 ? s : (s + 9)) & 0x0f);
            int _checkValue = (_checkList.First() << 4) + _checkList.Last();

            var _recBuff = _recList.Take(_len - 2);

            int checksum = _recBuff.Xor();

            return checksum == _checkValue;
        }


    }
}
