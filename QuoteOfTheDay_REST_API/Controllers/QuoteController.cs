using QuoteOfTheDay_REST_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuoteOfTheDay_REST_API.Controllers
{
    public class QuoteController : ApiController
    {
        
        public HttpResponseMessage Get()
        {
            using (Quotes_DBContext db = new Quotes_DBContext())
            {
                Random random = new Random();
                int totalCount = db.QuoteLists.Count();

                // Generate a random index within the range of available quotes
                int randomIndex = random.Next(0, totalCount);

                // Retrieve a random quote using the generated index
                var randomQuote = db.QuoteLists.OrderBy(q => Guid.NewGuid()).Skip(randomIndex).FirstOrDefault();

                return Request.CreateResponse(HttpStatusCode.OK,randomQuote);
            }

        }

        public HttpResponseMessage Get(string name)
        {
            using (Quotes_DBContext db = new Quotes_DBContext())
            {
                if(name != null)
                {
                    var model = db.QuoteLists.FirstOrDefault(el => el.AuthorName.ToLower() == name.ToLower());
                    return model!=null? Request.CreateResponse(HttpStatusCode.OK, model) : Request.CreateResponse(HttpStatusCode.NotFound, "Can Not Fount Auther Name : " + name);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
        }

        public HttpResponseMessage Post([FromBody] QuoteList value)
        {
            try
            {
                if(ModelState.IsValid)
                { 
                    using(Quotes_DBContext db = new Quotes_DBContext())
                    {
                        db.QuoteLists.Add(value);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.Created, "Quote is Added Successfully!");
                    }
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "data is not in correct format!");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, "It's My Mistake!");
            }
        }

        public HttpResponseMessage Put(int id, [FromBody] QuoteList value)
        {
            try
            {
                if(id != 0 && ModelState.IsValid)
                {
                    using(Quotes_DBContext db = new Quotes_DBContext())
                    {
                        var model = db.QuoteLists.FirstOrDefault(el => el.ID == id);
                        if (model != null)
                        {
                            model.AuthorName = value.AuthorName;
                            model.Quote = value.Quote;
                            db.SaveChanges();
                            return Request.CreateResponse(HttpStatusCode.Accepted, "Quote Is Updated!");
                        }
                    }
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "data or id is Not Correct!");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, "It's My Mistake!");
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            using(Quotes_DBContext db = new Quotes_DBContext())
            {
                QuoteList model = db.QuoteLists.FirstOrDefault(el => el.ID == id);
                if(model != null)
                {
                    db.QuoteLists.Remove(model);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Accepted, "Quote Deleted Successfully!");
                }
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Id is Not Available!");
            }
        }
    }
}
