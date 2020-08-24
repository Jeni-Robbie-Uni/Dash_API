using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_dash.UtilityClasses
{
    public class GeoLocationService
    {
        public static int CalculatePointDistance(float longitudeEvent, float longitudeUser, float latitudeEvent, float latitudeUser)
        {
          
            const double earthRadius = 6376500.0;
            //Haversine formula takes into account earth curvature
            //Getdistance geo class doesnt exist in core so used the haversine stated 
            //chosen cause error rate is no more than .3%
            
            var long1 = longitudeEvent * (Math.PI / 180.0);
            var lat1 = latitudeEvent * (Math.PI / 180.0);   //converts to radians
            var lat2 = latitudeUser * (Math.PI / 180.0);
            var longDiff= longitudeUser * (Math.PI / 180.0)- long1;
           
            var raw = Math.Pow(Math.Sin((lat2 - lat1) / 2.0), 2.0) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(longDiff / 2.0), 2.0);
            double calcDistance = earthRadius * (2.0 * Math.Atan2(Math.Sqrt(raw), Math.Sqrt(1.0 - raw)));
            return Convert.ToInt32(calcDistance);
        }

    }
}
