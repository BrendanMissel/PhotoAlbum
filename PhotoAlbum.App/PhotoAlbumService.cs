using Newtonsoft.Json;
using PhotoAlbum.App.Model;

namespace PhotoAlbum.App
{
    public static class PhotoAlbumService
    {
        private const string BASE_PHOTO_ALBUM_URL = @"https://jsonplaceholder.typicode.com/photos?albumId=";
        private const string BAD_INPUT_RESPONSE = "Input invalid: Please enter a numeric album id.";
        private const string EMPTY_RESULTS = "[]";
        private const string EMPTY_RESULTS_RESPONSE = "No photos found with given album id:";
        
        /// <summary>
        /// Given a specified album id, return the collection of photos 
        /// associated with the album.
        /// </summary>
        /// <param name="userInput">Raw user input from the command line.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetPhotosByAlbumId(string? userInput)
        {
            List<string> photos = new();
            List<string> errors = new();

            errors = ScrubUserInput(ref userInput);

            // If we encountered an error during input scrubbing, return the errors to the caller
            if (errors.Count > 0)
            {
                return errors;
            }

            photos = RequestPhotosInSpecifiedId(userInput);

            return photos;
        }

        /// <summary>
        /// Given scrubbed user input, request all photos for the specified id
        /// </summary>
        /// <param name="scrubbedInput">The scrubbed user input.</param>
        /// <returns>The results of the query as an List<string> formatted: "[id] title"</returns>
        private static List<string> RequestPhotosInSpecifiedId(string? scrubbedInput)
        {
            List<string> photosReceived = new();
            HttpClient client = new();

            // Reach out to the specified url and request the photos of the album id
            var response = client.GetStringAsync(BASE_PHOTO_ALBUM_URL + scrubbedInput);
            string json = response.Result;

            // Empty results likely indicate the id a valid format but too large for the 
            // given dataset.
            if (json == EMPTY_RESULTS)
            {
                photosReceived.Add($"{EMPTY_RESULTS_RESPONSE} {scrubbedInput}");
                return photosReceived;
            }

            var album = JsonConvert.DeserializeObject<IEnumerable<Photo>>(json);
            
            // If our album is returned, format each photo string and add it to the collection
            if (album != null)
            {
                foreach (Photo pic in album)
                {
                    photosReceived.Add($"[{pic.Id}] {pic.Title}");
                }
            }

            return photosReceived;
        }

        /// <summary>
        /// Given raw user input, ensure it is not null, empty, and a positive integer value. 
        /// </summary>
        /// <param name="userInput">Raw user input from the command line.</param>
        /// <returns>If bad input is detected an error message will be returned to the caller.</returns>
        private static List<string> ScrubUserInput(ref string? userInput)
        {
            List<string> errorMessages = new();

            bool isEmpty = userInput == null || userInput == string.Empty;
            bool isNumeric = int.TryParse(userInput, out int id);

            // Here, I'm assuming the index starts at 1 (rather than 0) as the full dataset shows
            bool isNegative = isNumeric && id <= 0; 

            if (isEmpty || !isNumeric || isNegative) 
            {
                errorMessages.Add(BAD_INPUT_RESPONSE);
                return errorMessages;
            }

            // No errors found and user input is valid
            userInput = id.ToString();
            return errorMessages;
        }
    }
}
