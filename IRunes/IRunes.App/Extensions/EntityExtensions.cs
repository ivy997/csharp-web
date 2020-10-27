namespace IRunes.App.Extensions
{
	using IRunes.Models;
	using System.Linq;
	using System.Net;

	public static class EntityExtensions
	{
		public static string ToHtmlAll(this Album album)
		{
			return $"<h4><a href=\"/Albums/Details?id={album.Id}\">{WebUtility.UrlDecode(album.Name)}</a></h4>";
		}

		public static string ToHtmlDetails(this Album album)
		{
			return "<div class=\"album-details d-flex justify-content-between row\">" +
				   "	<div class=\"album-data col-md-5\">" +
				   $"		<img src=\"{WebUtility.UrlDecode(album.Cover)}\" class=\"img-thumbnail\" width=\"600\" height=\"300\">" +
				   $"		<h1 class=\"text-dark text-center\">Album Name: {WebUtility.UrlDecode(album.Name)}</h1>" +
				   $"		<h1 class=\"text-dark text-center\">Album Price: ${album.Price}</h1>" +
				   "		<div class=\"d-flex justify-content-between mb-5\">" +
				   $"			<a class=\"btn btn-success text-white\" href=\"/Tracks/Create?albumId={album.Id}\">Create Tracks</a>" +
				   "			<a class=\"btn btn-success text-white\" href=\"/Albums/All\">Back To All</a>" +
				   "		</div>" +
				   "	</div>" +
				   "	<div class=\"album-tracks col-md-6\">" +
				   "		<h1 class=\"text-dark\">Tracks</h1>" +
				   $"       <div class=\"ml-5\">{GetTracks(album)}</div>" +
				   "	</div>" +
				   "</div>";
		}

		public static string ToHtmlAll(this Track track, string albumId, int index)
		{
			return $"<li><strong>{index}</strong>. <a href=\"/Tracks/Details?albumId={albumId}&trackId={track.Id}\">{WebUtility.UrlDecode(track.Name)}</a></li>";
		}

		public static string ToHtmlDetails(this Track track)
		{
			return "<div class=\"track-details w-50 mx-auto\">" +
				   $"	<h3 class=\"text-center text-dark\">Track Name: {WebUtility.UrlDecode(track.Name)}</h1>" +
				   $"	<h3 class=\"text-center text-dark\">Track Price: ${track.Price:f2}</h1>" +
				   "	<hr class=\"bg-success\" style=\"height: 2px\" />" +
				   "	<div class=\"container\">" +
				   $"		<iframe class=\"responsive-iframe\" src=\"{WebUtility.UrlDecode(track.Link)}\" allowfullscreen></iframe>" +
				   "	</div>" +
				   "</div>";
		}

		private static string GetTracks(Album album)
		{
			return album.Tracks.Count == 0
				? "There are currently no tracks in this album."
				: string.Join("", album.Tracks.Select((track, index) => track.ToHtmlAll(album.Id, index + 1)));
		}
	}
}
