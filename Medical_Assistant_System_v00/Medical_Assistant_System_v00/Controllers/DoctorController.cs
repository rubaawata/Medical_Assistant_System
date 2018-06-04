using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medical_Assistant_System_v00.Controllers
{
    public class DoctorController : ApiController{

        [HttpGet]
        public HttpResponseMessage GetProfileDetails(int Id){

            using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){

                var entity = entities.Doctors.FirstOrDefault(d => d.Id_Doctor == Id);

                if(entity != null){
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else{
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with id = " + Id.ToString() + " not found");
                }
            }
        }

        [HttpGet]
        //display list of appointements
        public HttpResponseMessage GetAppointmentsDetails(int Id){

            using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){

                var entity = entities.Available_Appointment.Select(ap => ap.Id_Doctor == Id);

                if(entity != null){
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else{
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Appointement for Doctor with id = " + Id.ToString() + " not found");
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage PostNewAvailableAppointment([FromBody] Available_Appointment newAvailableAppointment){
            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                    entities.Available_Appointment.Add(newAvailableAppointment);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, newAvailableAppointment);
                    message.Headers.Location = new Uri(Request.RequestUri + newAvailableAppointment.Id_Available_Appointment.ToString());
                    return message;
                }
            }
            catch(Exception ex){

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage PostNewDoctor([FromBody] Doctor newDoctor){
            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                    entities.Doctors.Add(newDoctor);
                    entities.SaveChanges();
                    //response 
                    var message = Request.CreateResponse(HttpStatusCode.Created, newDoctor);
                    message.Headers.Location = new Uri(Request.RequestUri + newDoctor.Id_Doctor.ToString());
                    return message;
                }
            }
            catch(Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage PutProfile(int id, Doctor doctor){
            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                    var entity = entities.Doctors.FirstOrDefault(d => d.Id_Doctor == id);

                    if (entity != null) {
                        entity.Phone_Number = doctor.Phone_Number;
                        entity.Syndicate_num = doctor.Syndicate_num;

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with id =" + id.ToString() + " not found to update");
                    }
                }
            }
            catch (Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage PutAvailableAppointment(int apointement_id, Available_Appointment availableAppointment){

            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){

                    var entity = entities.Available_Appointment.FirstOrDefault(ap => ap.Id_Available_Appointment == apointement_id);

                    if(entity != null){
                        entity.Available_Time = availableAppointment.Available_Time;
                        entity.Prescriptions = availableAppointment.Prescriptions;

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else{
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "apointement with id =" + apointement_id.ToString() + " not found to update");
                    }

                } 
            }
            catch (Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteDoctor(int id){
            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {
                    var entity = entities.Doctors.FirstOrDefault(e => e.Id_Doctor == id);
                    if (entity != null){
                        entities.Doctors.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else{
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with id = " + id.ToString() + " not found to delete");
                    }
                }
            }catch(Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteAppointment(int id){

            try{

                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){
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
            }catch(Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteAvailableApointment(int id){

            return Ok();
        }
    }
}
