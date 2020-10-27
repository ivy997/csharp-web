﻿namespace IRunes.App.Controllers
{
	using IRunes.Data;
	using IRunes.Models;
	using SIS.HTTP.Requests.Contracts;
	using SIS.HTTP.Responses.Contracts;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security.Cryptography;
	using System.Text;

	public class UsersController : BaseController
	{
		public IHttpResponse Login(IHttpRequest httpRequest)
		{
			return this.View();
		}
		public IHttpResponse LoginConfirm(IHttpRequest httpRequest)
		{
			using (var context = new RunesDbContext())
			{
				string username = ((ISet<string>)httpRequest.FormData["username"]).FirstOrDefault();
				string password = ((ISet<string>)httpRequest.FormData["password"]).FirstOrDefault();

				User userFromDb = context.Users.FirstOrDefault(u => u.Username == username
																 || u.Email == username
																 && u.Password == this.HashPassword(password));

				if(userFromDb == null)
				{
					return this.Redirect("/Users/Login");
				}

				this.SignIn(httpRequest, userFromDb);
			}

			return this.Redirect("/");
		}

		public IHttpResponse Register(IHttpRequest httpRequest)
		{
			return this.View();
		}
		public IHttpResponse RegisterConfirm(IHttpRequest httpRequest)
		{
			using (var context = new RunesDbContext())
			{
				string username = ((ISet<string>)httpRequest.FormData["username"]).FirstOrDefault();
				string password = ((ISet<string>)httpRequest.FormData["password"]).FirstOrDefault();
				string confirmPassword = ((ISet<string>)httpRequest.FormData["confirmPassword"]).FirstOrDefault();
				string email = ((ISet<string>)httpRequest.FormData["email"]).FirstOrDefault();
				
				if (password != confirmPassword)
				{
					return this.Redirect("/Users/Register");
				}

				User user = new User()
				{
					Username = username,
					Password = this.HashPassword(password),
					Email = email
				};

				context.Users.Add(user);
				context.SaveChanges();
			}

			return this.Redirect("/Users/Login");
		}

		public IHttpResponse Logout(IHttpRequest httpRequest)
		{
			this.SignOut(httpRequest);

			return this.Redirect("/");
		}

		private string HashPassword(string password)
		{
			using (SHA256 sha256Hash = SHA256.Create())
			{
				return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
			}
		}
	}
}
