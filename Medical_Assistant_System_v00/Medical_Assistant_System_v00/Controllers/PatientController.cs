using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medical_Assistant_System_v00.Controllers
{
    public class PatientController : ApiController{

        [HttpGet]
        public HttpResponseMessage GetProfileDetails(int Id){

            using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){
                var entity = entities.P_Personal_Infomation.FirstOrDefault(p => p.Id_Patient == Id);

                if(entity != null){
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else{

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Profile with id = " + Id.ToString() + " not found");
                }
            }
        }

        [HttpGet]
        //Allergy or Prescriptions
        public IHttpActionResult GetHealthyRecord(int Id){

            // code
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult GetAppointmentsDetails(int Id){

            // code
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult GetFirstAid(string Diseases){
            // code
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult CallEmergency(int id){

            return NotFound();
        }

        [HttpPost]
        public HttpResponseMessage PostNewPatient([FromBody] P_Personal_Infomation newPatient){

            try
            {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities())
                {

                    entities.P_Personal_Infomation.Add(newPatient);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, newPatient);
                    message.Headers.Location = new Uri(Request.RequestUri + newPatient.Id_Patient.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        //test.....
        public HttpResponseMessage PostNewAppointment([FromBody] Available_Appointment newAppointment){

            try
            {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities())
                {

                    entities.Available_Appointment.Add(newAppointment);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, newAppointment);
                    message.Headers.Location = new Uri(Request.RequestUri + newAppointment.Id_Available_Appointment.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage putProfile(int Patient_id, P_Personal_Infomation patient){

            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){

                    var entity = entities.P_Personal_Infomation.FirstOrDefault(p => p.Id_Patient == Patient_id);

                    if (entity != null){
                        entity.Patient_Account = patient.Patient_Account;
                        entity.Patient_Allergy = patient.Patient_Allergy;
                        entity.Prescriptions = patient.Prescriptions;
                        entity.SocialStatus = patient.SocialStatus;
                        entity.Length_p = patient.Length_p;
                        entity.weight_p = patient.weight_p;
                        entity.Emergencies = patient.Emergencies;

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else{
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with id =" + Patient_id.ToString() + " not found to update");
                    }
                }

            }
            catch (Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeletePateint(int id){

            try{
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){

                    var entity = entities.P_Personal_Infomation.FirstOrDefault(p => p.Id_Patient == id);
                    if (entity != null){
                        entities.P_Personal_Infomation.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else{
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient with id = " + id + " not found to delete");
                    }
                }
            }
            catch (Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteAppointment(int id){

            try{
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities())
                {
                    var entity = entities.Available_Appointment.FirstOrDefault(ap => ap.Id_Available_Appointment == id);
                    if (entity != null){
                        entities.Available_Appointment.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else{
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Appointement with id = " + id.ToString() + " not found to delete");
                    }

                }
            }
            catch (Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public void Diagnosis(){

        }
    }
}
