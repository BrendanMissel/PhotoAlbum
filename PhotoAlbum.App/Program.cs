using PhotoAlbum.App;
if(args.Length > 0)
{
    IEnumerable<string> photos = PhotoAlbumService.GetPhotosByAlbumId(args[0]);

    foreach (string photo in photos)
    {
        Console.WriteLine(photo);
    }
}
else
{
    Console.WriteLine("No argument provided.");
}

