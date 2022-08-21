using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SensorData : BaseDTO
    {
        public decimal ID
        {
            get;
            set;
        }
        public long TS
        {
            get;
            set;
        }
        public string veh_id
        {
            get; set;
        }

        public decimal p1
        {
            get;
            set;
        }

        public decimal p2
        {
            get;
            set;
        }

        public decimal p3
        {
            get;
            set;
        }

        public decimal p4
        {
            get;
            set;
        }

        public decimal p5
        {
            get;
            set;
        }

        public decimal p6
        {
            get;
            set;
        }

        public decimal t1
        {
            get;
            set;
        }

        public decimal t2
        {
            get;
            set;
        }

        public decimal t3
        {
            get;
            set;
        }

        public decimal t4
        {
            get;
            set;
        }

        public decimal t5
        {
            get;
            set;
        }

        public decimal t6
        {
            get;
            set;
        }

        public decimal Eng
        {
            get;
            set;
        }

        public decimal Power
        {
            get;
            set;
        }

        public decimal Battery
        {
            get;
            set;
        }

        public decimal Lat
        {
            get;
            set;
        }

        public decimal Lon
        {
            get;
            set;
        }

        public decimal BLE
        {
            get;
            set;
        }

        public decimal Mem
        {
            get;
            set;
        }

        public decimal X_axis
        {
            get;
            set;
        }
        public decimal Y_axis
        {
            get;
            set;
        }
        public decimal Z_axis
        {
            get;
            set;
        }
    }
}
