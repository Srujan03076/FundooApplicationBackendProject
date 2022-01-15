using BussinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooAppLication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelBL labelBL;
        public LabelController(ILabelBL labelBL)
        {
            this.labelBL = labelBL;
        }
        /// <summary>
        /// API for adding the label in notes in the web application
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="labelModel"></param>
        /// <returns></returns>
        [HttpPost("MakeALabel")]
        public IActionResult MakeALabel(LabelModel labelModel)
        {
            try
            {
                var result = this.labelBL.MakeALabel(labelModel);
                if (result != null)
                {
                    
                    return Ok(new { Success = true, message = "Label added Successfully", Data=labelModel });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Adding Label Failed" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for getting all the labels from database in the web application
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetLabels")]
        public IActionResult Getlabels()
        {
            try
            {
                var labelDetails = this.labelBL.Getlabels();
                if (labelDetails == null)
                {
                    return this.BadRequest(new { Success = false, message = " Label records not found" });
                }
                else
                {
                    return this.Ok(new { Success = true, message = "Label records found", labeldata = labelDetails });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for edit labels in notes in the web application
        /// </summary>
        /// <param name="labelId"></param>
        /// <param name="labelModel"></param>
        /// <returns></returns>
        [HttpPut("{labelId}/EditLabel")]
        
        public IActionResult EditLabel(long labelId, LabelModel labelModel)
        {
            try
            {
                var result = this.labelBL.EditLabel(labelId, labelModel);
                if (result !=null)
                {
                    return Ok(new { Success = true, message = "Label changed Successfully", Data= labelModel });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Label chaning Failed" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for deleting labels in notes in the web application
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("DeleteLabel")]
        public IActionResult DeleteLabel(LabelModel model)
        {
            try
            {
                var deletelabel = this.labelBL.Deletelabel(model);
                if (deletelabel == true)
                {
                    return this.Ok(new { Success = true, message = "Delete Label successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = " Delete label Failed" });
                }

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }

    }
}
