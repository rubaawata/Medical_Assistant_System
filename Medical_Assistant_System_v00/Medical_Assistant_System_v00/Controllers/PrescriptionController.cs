using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medical_Assistant_System_v00.Controllers
{
    public class PrescriptionController : ApiController{

      /*  [HttpPost]
        public HttpResponseMessage PostNewSymptom([FromBody] Symptom newSymptom){

            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                    entities.Symptoms.Add(newSymptom);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, newSymptom);
                    message.Headers.Location = new Uri(Request.RequestUri + newSymptom.Id_Symptoms.ToString());
                    return message;
                }
            }
            catch(Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        */
        [HttpPost]
        public HttpResponseMessage PostNewMedicine([FromBody] Medicine newMedicine){

            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                    entities.Medicines.Add(newMedicine);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, newMedicine);
                    message.Headers.Location = new Uri(Request.RequestUri + newMedicine.Id_Medicine.ToString());
                    return message;
                }
            }
            catch(Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage PostNewPrescription([FromBody] Prescription newPrescription){

            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                    entities.Prescriptions.Add(newPrescription);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, newPrescription);
                    message.Headers.Location = new Uri(Request.RequestUri + newPrescription.Id_Prescription.ToString());
                    return message;
                }
            }
            catch(Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public IHttpActionResult PutDiagnosis(){

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult PutSymptom(Symptom symptom){

            return Ok();
        }

        [HttpPut]
        public HttpResponseMessage PutMedicine(int prescription_id, Medicine medicine){

            try
            {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities())
                {
                    var entity = entities.Prescriptions.FirstOrDefault(p => p.Id_Prescription == prescription_id);
                    if (entity != null)
                    {
                        //add new medcine to the prescription
                        entity.Medicines.Add(medicine);

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Prescription with id =" + prescription_id.ToString() + " not found to update symptom in it");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
