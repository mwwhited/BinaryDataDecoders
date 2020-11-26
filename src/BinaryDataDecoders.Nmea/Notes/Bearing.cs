using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1
{
    public class Bearing
    {
        private float _bearing;

        public Bearing(float bearing)
        {
            _bearing = bearing;
        }

        public Bearing(string bearing)
        {
            if (string.IsNullOrEmpty(bearing))
                throw new ArgumentNullException("Bearing can not be null or empty");

            _bearing = float.Parse(bearing);
        }

        public float Heading
        {
            get
            {
                return _bearing;
            }
        }

        public GeneralHeading GeneralHeading
        {
            get
            {
                return _bearing.GetGeneralHeading();
            }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1:##0.0000}°)", 
                new object[]{
                    GeneralHeading.ToString().Replace("_","-"),
                    _bearing
                });
        }

    }
}
