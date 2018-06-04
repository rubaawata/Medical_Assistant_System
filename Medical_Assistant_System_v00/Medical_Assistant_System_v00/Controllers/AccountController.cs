using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medical_Assistant_System_v00.Controllers
{
    public class AccountController : ApiController{

       // [HttpGet]
        [Route("Account/details")]
        [HttpGet]
        public HttpResponseMessage GetAccountDetails(string phoneNumber){

            using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){

                var entity = entities.Patient_Account.FirstOrDefault(p=>p.Phone_Number.Equals(phoneNumber));

                if(entity != null){
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else{
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Account with phone = " + phoneNumber + " not found");
                }
            }
               
        }
        [HttpGet]
        public IHttpActionResult SwitchIndividual(int Id){
            

            return NotFound();
        }

        [HttpPost]
        public HttpResponseMessage PostNewAccount([FromBody] Patient_Account newAccount){

            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){

                    entities.Patient_Account.Add(newAccount);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, newAccount);
                    message.Headers.Location = new Uri(Request.RequestUri + newAccount.Id_Account.ToString());
                    return message;
                }
            }
            catch (Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }


        [HttpPut]
        //test...
        public HttpResponseMessage PutAccount(int id, Patient_Account newAccount){
            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                    var entity = entities.Patient_Account.FirstOrDefault(p => p.Id_Account == id);
                    if (entity != null) {
                        entity.Phone_Number = newAccount.Phone_Number;
                        entity.P_Personal_Infomation.Add((P_Personal_Infomation)newAccount.P_Personal_Infomation);

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Account with id =" + id.ToString() + " not found to update");
                    }
                }
            }
            catch (Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteAccount(string phoneNumber){

            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){

                    var entity = entities.Patient_Account.FirstOrDefault(p => p.Phone_Number == phoneNumber);
                    if(entity != null){
                        entities.Patient_Account.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else{
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Account with phone = " + phoneNumber + " not found to delete");
                    }
                }
            } catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
