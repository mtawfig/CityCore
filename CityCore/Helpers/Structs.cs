using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityCore.Helpers
{
    struct PagesList
    {
        public static string LoginPage = "login";
        public static string HomePage = "home";
        public static string SettingsPage = "sett";
        public static string UsersPage = "user";

        public static string DriversDashboard = "drivers_dash";
        public static string DriversManage = "drivers_mgmt";
        public static string DriversReport = "drivers_rept";

        public static string RidersDashboard = "riders_dash";
        public static string RidersManage = "riders_mgmt";
        public static string RidersReport = "riders_rept";

        public static string TripsDashboard = "trips_dash";
        public static string TripsManage = "trips_mgmt";
        public static string TripsReport = "trips_rept";

        public static string CarsDashboard = "cars_dash";
        public static string CarsManage = "cars_mgmt";
        public static string CarsReport = "cars_rept";
        public static string CarTypes = "cars_types";
        public static string CarsView = "cars_view";

        public static string ClientsDashboard = "cars_dash";
        public static string ClientsManage = "clients_mgmt";
        public static string ClientsAdd = "cars_mgmt";
        public static string ClientsEdit = "cars_rept";
    }

    public struct PROJECT_LEVEL
    {
        public static string DESIGNING = "DESIGNING";
        public static string PERMITTING = "PERMITTING";
        public static string TENDERING = "TENDERING";
        public static string SUPERVISION = "SUPERVISION";
    };

    public struct PROJECT_STATUS
    {
        public static string NEW = "NEW";
        public static string ACTIVE = "ACTIVE";
        public static string FULL_DONE = "FULL DONE";
        public static string HOLDING = "HOLDING";
        public static string VACANT = "VACANT";
    };

    public struct TASK_STATUS
    {
        public static string NEED_ACTION = "NEED ACTION";
        public static string SUBMITTED = "SUBMITTED";
        public static string CORRECTION = "CORRECTION";
        public static string APPROVED = "APPROVED";
        public static string WAITING = "WAITING";
    };

    public struct TASK_CATEGORY
    {
        public static string DESIGNING = "DESIGNING";
        public static string PERMITTING = "PERMITTING";
        public static string TENDERING = "TENDERING";
        public static string SUPERVISION = "SUPERVISION";
    };

}