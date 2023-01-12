using PhotoAlbum.App;

var albumId = Environment.GetCommandLineArgs()[1];

PhotoAlbumService.GetPhotosByAlbumId(albumId);
