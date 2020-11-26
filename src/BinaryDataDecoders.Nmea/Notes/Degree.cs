using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1
{
    //http://en.wikipedia.org/wiki/Geographic_coordinate
    public class Degree
    {
        private float _degree;
        private string _hemisphere;

        public Degree(float degree)
        {
            _degree = degree;
        }

        /// <summary>
        /// HHHMM.M
        /// </summary>
        /// <param name="degree"></param>
        /// <param name="hemisphere"></param>
        public Degree(string degree, string hemisphere)
        {
            if (string.IsNullOrEmpty(degree) || string.IsNullOrEmpty(hemisphere))
                throw new NullReferenceException("Degree and Hemisphere should not be null or empty");

            int point = degree.IndexOf(".");

            if (point == -1)
                throw new NullReferenceException("Degree should be formatted like HHHMM.Mmm");

            _degree = (
                float.Parse(degree.Substring(0, point - 2)) +
                (float.Parse(degree.Substring(point - 2)) / 60)
                );

            _hemisphere = hemisphere.Substring(0, 1);
            if (_hemisphere  == "S" || _hemisphere == "W")
                _degree = Math.Abs(_degree) * -1;
        }

        #region DD

        public decimal DecimalDegree
        {
            get
            {
                return Math.Round((decimal)_degree, 4);
            }
        }

        #endregion

        #region DMS

        /// <summary>
        /// ##°##'##.000"H
        /// </summary>
        public string DegreeMinuteSecondH
        {
            get
            {
                float m_degTemp = Math.Abs(_degree);
                int m_deg = (int)m_degTemp;
                float m_minTemp = (m_degTemp - m_deg) * 60;
                int m_min = (int)m_minTemp;
                float m_sec = (m_minTemp - m_min) * 60;

                return string.Format("{0:###}°{1:###}'{2:###.000}\"{3}",
                    new object[] {
                        m_deg,
                        m_min,
                        m_sec,
                        _hemisphere
                    });
            }
        }

        /// <summary>
        /// ##d##m##.000sH
        /// </summary>
        public string DegreeMinuteSecondHA
        {
            get
            {
                float m_degTemp = Math.Abs(_degree);
                int m_deg = (int)m_degTemp;
                float m_minTemp = (m_degTemp - m_deg) * 60;
                int m_min = (int)m_minTemp;
                float m_sec = (m_minTemp - m_min) * 60;

                return string.Format("{0:###}d{1:###}m{2:###.000}s{3}",
                    new object[] {
                        m_deg,
                        m_min,
                        m_sec,
                        _hemisphere
                    });
            }
        }

        /// <summary>
        /// ±###°##'##.000"
        /// </summary>
        public string DegreeMinuteSecond
        {
            get
            {
                int m_dir = _degree > 0 ? 1 : -1;
                float m_degTemp = Math.Abs(_degree);
                int m_deg = (int)m_degTemp;
                float m_minTemp = (m_degTemp - m_deg) * 60;
                int m_min = (int)m_minTemp;
                float m_sec = (m_minTemp - m_min) * 60;

                return string.Format("{0:###}°{1:###}'{2:###.000}\"",
                    new object[] {
                        m_deg * m_dir,
                        m_min,
                        m_sec
                    });
            }
        }

        /// <summary>
        /// ±###d##m##.000s
        /// </summary>
        public string DegreeMinuteSecondA
        {
            get
            {
                int m_dir = _degree > 0 ? 1 : -1;
                float m_degTemp = Math.Abs(_degree);
                int m_deg = (int)m_degTemp;
                float m_minTemp = (m_degTemp - m_deg) * 60;
                int m_min = (int)m_minTemp;
                float m_sec = (m_minTemp - m_min) * 60;

                return string.Format("{0:###}d{1:###}m{2:###.000}s",
                    new object[] {
                        m_deg * m_dir,
                        m_min,
                        m_sec
                    });
            }
        }

        #endregion

        #region DM

        /// <summary>
        /// ±###°##.000'
        /// </summary>
        public string DegreeMinute
        {
            get
            {
                int m_dir = _degree > 0 ? 1 : -1;
                float m_degTemp = Math.Abs(_degree);
                int m_deg = (int)m_degTemp;
                float m_min = (m_degTemp - m_deg) * 60;

                return string.Format("{0:###}°{1:###.000}'",
                    new object[] {
                        m_deg * m_dir,
                        m_min
                    });
            }
        }

        /// <summary>
        /// ±###d##.000m
        /// </summary>
        public string DegreeMinuteA
        {
            get
            {
                int m_dir = _degree > 0 ? 1 : -1;
                float m_degTemp = Math.Abs(_degree);
                int m_deg = (int)m_degTemp;
                float m_min = (m_degTemp - m_deg) * 60;

                return string.Format("{0:###}d{1:###.000}m",
                    new object[] {
                        m_deg * m_dir,
                        m_min
                    });
            }
        }

        #endregion

        public override string ToString()
        {
            return DegreeMinuteSecondH;
        }
    }
}
