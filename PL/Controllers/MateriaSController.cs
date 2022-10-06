using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaSController : Controller
    {
        // GET: Alumno
        [HttpGet]
        public ActionResult GetAll() {

            ML.Materia materia = new ML.Materia();

            string uri = ConfigurationManager.AppSettings["WebApi"].ToString();

            ML.Result resultApi = new ML.Result();

            using (var client = new HttpClient()) {
                
                client.BaseAddress = new Uri(uri);

                var responseTask = client.GetAsync("Materia/GetAll");
                responseTask.Wait();

                var resultService = responseTask.Result;

                if (resultService.IsSuccessStatusCode) {
                    
                    var readTask = resultService.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();
                    resultApi.Objects = new List<object>();

                    foreach (var item in readTask.Result.Objects)
                    {

                        ML.Materia resultMateria = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>( item.ToString());
                        resultApi.Objects.Add(resultMateria);

                    }
                }
            
            }

            materia.Materias = resultApi.Objects;

            return View(materia);

        }

        [HttpGet]
        public ActionResult Form(int? IdMateria) {

            ML.Materia materia = new ML.Materia();
            string uri = ConfigurationManager.AppSettings["WebApi"].ToString();

            if (IdMateria == null)
            {

                return View(materia);

            }
            else {

                ML.Result resultApi = new ML.Result();

                using (var client = new HttpClient()) {

                    client.BaseAddress = new Uri(uri);
                    var responseTask = client.GetAsync("Materia/GetByid/?IdMateria=" + IdMateria);

                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode) {

                        var readTask = result.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        resultApi.Object = new List<Object>();

                        var resultItem = readTask.Result.Object;

                        ML.Materia resultMateria = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());

                        resultApi.Object = resultMateria;
                    }

                
                }

                materia = (ML.Materia)resultApi.Object;
            
            }

            return View(materia);
        
        }


        [HttpPost]
        public ActionResult Form(ML.Materia materia) {

            string uri = ConfigurationManager.AppSettings["WebApi"].ToString();

            if (materia.IdMateria == 0)
            {

                
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(uri);

                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", materia);
                    postTask.Wait();

                    var resultService = postTask.Result;

                    if (resultService.IsSuccessStatusCode)
                    {

                        ViewBag.Mensaje = ("Materia agregada");
                        return RedirectToAction("Modal");

                    }
                    else
                    {

                        ViewBag.Mensaje = ("Ocurrio un error");
                        return RedirectToAction("Modal");
                    }

                }

            }
            else {

                using (var client = new HttpClient()) {

                    client.BaseAddress = new Uri(uri);

                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Update",materia);

                    postTask.Wait();

                    var resultService = postTask.Result;

                    if (resultService.IsSuccessStatusCode) {

                        ViewBag.Mensaje = ("Materia actualizada");
                        return RedirectToAction("Modal");
                    }
                    else {

                        ViewBag.Mensaje = ("Error al actualizar");
                        return RedirectToAction("Modal");

                    }
                }
            }

            return View(materia);
        }






    }
}