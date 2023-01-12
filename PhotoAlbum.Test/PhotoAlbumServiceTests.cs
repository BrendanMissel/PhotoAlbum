using PhotoAlbum.App;
using static PhotoAlbum.Test.ExpectedResults;

namespace PhotoAlbum.Test;

public class PhotoAlbumServiceTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("j")]
    [InlineData("@")]
    [InlineData("A1")]
    [InlineData("-9")]
    [InlineData("0")]
    public void GetPhotosByAlbumId_HandlesBadInput(string? input)
    {
        IEnumerable<string> actual = PhotoAlbumService.GetPhotosByAlbumId(input);

        Assert.Equivalent(EXPECTED_BAD_INPUT_RESPONSE, actual);
    }

    [Fact]
    public void GetPhotosByAlbumId_ReturnsInCorrectFormat()
    {    
        IEnumerable<string> photos = PhotoAlbumService.GetPhotosByAlbumId("1");
        string? actual = photos.FirstOrDefault();

        Assert.Equal(EXPECTED_OUTPUT_PHOTO_ID_1, actual);
    }

    [Theory]
    [InlineData("5001")]
    [InlineData("2147483647")]
    public void GetPhotosByAlbumId_HandlesNoResults(string? input)
    {
        List<string> expected = new() { $"{EXPECTED_NO_OUTPUTS_RESPONSE} {input}" };

        IEnumerable<string> actual = PhotoAlbumService.GetPhotosByAlbumId(input);

        Assert.Equivalent(expected, actual);
    }
}