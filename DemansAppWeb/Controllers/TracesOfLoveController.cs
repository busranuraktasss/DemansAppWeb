using DemansAppWeb.Helper.DTO.TracesOfLove;
using DemansAppWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemansAppWeb.Controllers
{
    public class TracesOfLoveController : Controller
    {

        private readonly EntitiesContext db;

        public TracesOfLoveController(EntitiesContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ShiftMap()
        {
            var shiftMap = db.TraceOfLoves
                .Select(s => new shiftMapRequest
                {
                    Lat = s.Lat,
                    Lng = s.Lng,
                    PlaceName = s.PlaceName

                }).ToList();

            return Json(new { status = true, data = shiftMap });


        }

        [HttpPost]
        public JsonResult ShowPlace(string cityName)
        {
            try
            {
                Request.Form.TryGetValue("draw", out Microsoft.Extensions.Primitives.StringValues drawOut);

                var draw = drawOut.FirstOrDefault();

                Request.Form.TryGetValue("start", out Microsoft.Extensions.Primitives.StringValues startOut);
                var start = startOut.FirstOrDefault();

                Request.Form.TryGetValue("length", out Microsoft.Extensions.Primitives.StringValues lengthOut);
                var length = lengthOut.FirstOrDefault();

                Request.Form.TryGetValue("order[0][column]", out Microsoft.Extensions.Primitives.StringValues orderColumnOut);
                Request.Form.TryGetValue("columns[" + orderColumnOut.FirstOrDefault() + "][name]", out Microsoft.Extensions.Primitives.StringValues columnsNameOut);
                var sortColumn = columnsNameOut.FirstOrDefault();

                Request.Form.TryGetValue("order[0][dir]", out Microsoft.Extensions.Primitives.StringValues sortColumnDirOut);
                var sortColumnDir = sortColumnDirOut.FirstOrDefault();

                Request.Form.TryGetValue("search[value]", out Microsoft.Extensions.Primitives.StringValues searchValueOut);
                var searchValue = searchValueOut.FirstOrDefault() ?? "";

                //Paging Size 
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                var recordsTotal = db.TraceOfLoves.Count();

                var _tracesOfLove_list = db.TraceOfLoves.Where(w => w.City == cityName)
                    .Select(s => new shiftMapRequest()
                    {
                        City = s.City,
                        PlaceName = s.PlaceName,
                        Phone = s.Phone,

                    }).Skip(skip).Take(pageSize).ToList();

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    switch (sortColumn)
                    {
                        case "PlaceName":
                            if (sortColumnDir == "desc")
                                _tracesOfLove_list = (from o in _tracesOfLove_list orderby o.PlaceName ascending select o).ToList();
                            else
                                _tracesOfLove_list = (from o in _tracesOfLove_list orderby o.PlaceName descending select o).ToList();
                            break;
                        case "Phone":
                            if (sortColumnDir == "desc")
                                _tracesOfLove_list = (from o in _tracesOfLove_list orderby o.Phone descending select o).ToList();
                            else
                                _tracesOfLove_list = (from o in _tracesOfLove_list orderby o.Phone ascending select o).ToList();
                            break;
                        
                        default:
                            if (sortColumnDir == "desc")
                                _tracesOfLove_list = (from o in _tracesOfLove_list orderby o.PlaceName descending select o).ToList();
                            else
                                _tracesOfLove_list = (from o in _tracesOfLove_list orderby o.PlaceName ascending select o).ToList();
                            break;
                    }
                }

                return Json(new
                {
                    draw = draw,
                    recordsFiltered = recordsTotal,
                    recordsTotal = recordsTotal,
                    data = _tracesOfLove_list
                });
            }
            catch (Exception ex)
            {
                return Json(new { status = true, data = "", messages = ex.Message });
            }
        }
    }
}
