using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVang.ExtendClass
{
    public sealed class UserAccess
    {
        private static UserAccess instance = null;
        private static readonly object padlock = new object();
        private static int UserId;
        private static int UserAccessLevel;
        private static string StaffName;
        public static UserAccess Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UserAccess();
                    }
                    return instance;
                }
            }
        }

        public int SetAccessLevel
        {
            set { UserAccessLevel = value; }
        }

        public int GetAccessLevel
        {
            get { return UserAccessLevel; }
        }

        public int SetUserId
        {
            set { UserId = value; }
        }
        public int GetUserId
        {
            get { return UserId; }
        }
        public string SetStaffName
        {
            set { StaffName = value; }
        }
        public string GetStaffName
        {
            get { return StaffName; }
        }
    }
}
