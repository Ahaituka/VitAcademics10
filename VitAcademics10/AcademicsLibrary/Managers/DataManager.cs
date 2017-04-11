using AcademicsLibrary.DataModel;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using AcademicsLibrary.Services;
using Microsoft.Toolkit.Uwp;

namespace AcademicsLibrary.Managers
{
    public class DataManager
    {

        public static  string keyLargeObject = "data.txt";
       public static  StorageFolder  localFolder = ApplicationData.Current.LocalFolder;



        public enum StatusCode
    {
        /// <summary>
        /// Successful execution.
        /// </summary>
        Success = 0,
        /// <summary>
        /// Connectivity or network issues.
        /// </summary>
        NoInternet = 1,
        /// <summary>
        /// Server errors such as "Unavailable", "Database Error" or "Gateway Timeout".
        /// </summary>
        ServerError = 2,
        /// <summary>
        /// The data has not changed from the previous version.
        /// </summary>
        NoChange = 3,
        /// <summary>
        /// An unknown error occured.
        /// </summary>
        UnknownError = 4,
        /// <summary>
        /// Occurs if the file or content is missing.
        /// </summary>
        NoData = 5,
        /// <summary>
        /// The service provider is busy.
        /// </summary>
        Busy = 6
    }


        private static readonly string FILE_NAME = "data.json";
        public static User user { get; private set; }

        private static readonly StorageFolder _folder = ApplicationData.Current.LocalFolder;

        public static RefreshModel Refresh { get; private set; }
        public static Response response { get; private set; }
        public static bool IsReady { get; private set; }
        public static RefreshModel Ref { get; private set; }

        public static async Task<StatusCode> LoginAsync(string campus ,string reg , string pass)
        {
             user = await NetworkService.NetworkService.Login(campus ,reg,pass);
            if (user.status.code==0)
            {          
              
                IsReady = true;
                return StatusCode.Success;
                //  await TrySaveDataAsync(response.Content);
            }
            else
            {
                return StatusCode.UnknownError;
            }   
        }

        public static async Task<StatusCode> RefreshDataAsync(string campus, string reg, string pass)
        {
            Refresh = await NetworkService.NetworkService.Refresh(campus, reg, pass);
            if (Refresh.status.code == 0)
            {
                IsReady = true;
                await TrySaveDataAsync();

                return StatusCode.Success;

            }
            else
            {
                return StatusCode.UnknownError;
            }
        }
        public static async Task<bool> LoadCacheAsync()
        {
            try
            {
                var helper = new LocalObjectStorageHelper();
                if (await helper.FileExistsAsync(keyLargeObject))
                {
                 Refresh = await helper.ReadFileAsync<RefreshModel>(keyLargeObject);                 
                    IsReady = true;
                    return true;
                }
                else
                {
                    IsReady = false;
                    return false;
                }
                //StorageFile file = await _folder.GetFileAsync(FILE_NAME);
                //string data = await Services.ContentSerializer.ContentManager.GetEventsJsonAsync(file);
                //if (data == null)
                //    return false;

                ////  var events = JsonParser.TryGetEvents(data);


                //  if (events == null)
                //      return false;
                //  var categories = GetCategories(events);

                //  EventList = events;
                //  CategoryList = categories;
               
            }
            catch
            {
                Reset();
                return false;
            }
        }

        private static async  Task<StatusCode> TrySaveDataAsync()
        {
            if (IsReady == false)
                return StatusCode.NoData;
            try
            {
                //StorageFile file = await _folder.CreateFileAsync(FILE_NAME, CreationCollisionOption.ReplaceExisting);
                //await ContentSerializer.ContentManager.TryWriteEventsJsonAsync(file, json);
                //return StatusCode.Success;

                StorageFile sampleFile = await localFolder.CreateFileAsync("data.txt", CreationCollisionOption.ReplaceExisting);
                var helper = new LocalObjectStorageHelper();
                await helper.SaveFileAsync(keyLargeObject, Refresh);
                return StatusCode.Success;
            }
            catch
            {
                return StatusCode.UnknownError;
            }
        }


        private static void Reset()
        {
            Refresh = null;
            IsReady = false;
        }

    }
}

