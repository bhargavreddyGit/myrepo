using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using ScDevDemo.Models;
using Sitecore.Mvc.Presentation;

namespace ScDevDemo.Controllers
{
    public class CarouselController : GlassController
    {
        // GET: Carousel
            public ActionResult GetCarousel()
            {
                CarouselData carouselModel = new CarouselData();
                Sitecore.Collections.ChildList slideItems = null;
                //Get the current context, then datasource item
                var currentContext = RenderingContext.Current;
                var currentRendering = currentContext.Rendering;
                var database = Sitecore.Context.Database;
                var dataSourceId = currentRendering.DataSource;
                //Create list of slide items underneath datasource item
                if (database.GetItem(dataSourceId) != null)
                {
                    var dataSource = database.GetItem(dataSourceId);
                    //Ideally you'd actually loop through these to verify against Slide template ID and populate a separate list then bind that to model object
                    slideItems = dataSource.GetChildren();
                }
                carouselModel.SlideItems = slideItems;
                return View("~/Views/Components/Carousel/Index.cshtml", carouselModel);
            }
    }
}