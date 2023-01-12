using static PhotoAlbum.Test.ExpectedResults;

namespace PhotoAlbum.Test;

public class PhotoAlbumServiceTests
{
    [Fact]
    public void GetPhotosByAlbumId_HandlesNull()
    {
        PhotoAlbumService albumService = new();

        IEnumerable<string> actual = albumService.GetPhotosByAlbumId(null);

        Assert.Equivalent(EXPECTED_BAD_INPUT_RESPONSE, actual);
    }
}