using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MainEntities.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MainEntities.WebApi.Controllers
{
    public class MainEntityController : Controller
    {
        private bool IsValid(MainEntity mainEntity)
        {
            if (mainEntity.Id < 0)
                return false;
            if (string.IsNullOrWhiteSpace(mainEntity.JsonValue))
                return false;
            if (mainEntity.ModuleId <= 0)
                return false;
            if (mainEntity.PatientIdInTrial <= 0)
                return false;
            if (mainEntity.VisitGroupId <= 0)
                return false;
            if (mainEntity.VisitId <= 0)
                return false;
            if (mainEntity.VisitIndexInVisitGroup <= 0)
                return false;
            if (mainEntity.DoctoryId <= 0)
                return false;
            if (mainEntity.ExperimentId <= 0)
                return false;
            return true;
        }

        public IActionResult GetAll(int experimentId = 1)
        {
            // TODO - validate user;
            var allEntities = new List<MainEntity>().Where(x => x.ExperimentId == experimentId);
            return Json(allEntities);
        }


        public IActionResult Update(MainEntity mainEntity)
        {
            try
            {
                // Logic checks
                if (mainEntity.Id == 0) mainEntity.GuidId = Guid.NewGuid().ToString();

                if (!IsValid(mainEntity))
                    return StatusCode((int)HttpStatusCode.BadRequest);

                // TODO - Authentication checks IsAutorized to access this experiment

                // TODO - repository insert/update

                return Json(new UpdateRespone() { is_success = true });
            }
            catch (Exception)
            {
                Json(new UpdateRespone() { is_success = false });
            }

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }


        public IActionResult GetByDetails(MainEntity partialDetails)
        {
            // TODO - Validate user
            MainEntity existingEntity = null;
            if (partialDetails == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            if (partialDetails.Id > 0 && !string.IsNullOrWhiteSpace(partialDetails.GuidId))
            {
                // TODO - get from week based repository
                existingEntity = new MainEntity();
            }
            else if (IsValid(partialDetails))
            {
                // TODO - get / create new from factory from week based repository
                existingEntity = new MainEntity();
            }
            else return StatusCode((int)HttpStatusCode.BadRequest);

            return Json(existingEntity);
        }


    }
}