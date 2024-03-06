using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjetSuiviGeek.Models;

namespace ProjetSuiviGeekServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuiviController : ControllerBase
    {
        private static List<FollowedItem> _FollowedItems = new List<FollowedItem>();

        [HttpGet]
        public IEnumerable<FollowedItem> Get()
        {
            return _FollowedItems;
        }

        [HttpPost]
        public ActionResult<FollowedItem> Ajouter(FollowedItem FollowedItem)
        {
            FollowedItem.Id = _FollowedItems.Count + 1;
            FollowedItem.StartDate = DateTime.Now;
            _FollowedItems.Add(FollowedItem);
            return FollowedItem;
        }

        [HttpPut("{id}")]
        public IActionResult Modifier(int id, FollowedItem FollowedItem)
        {
            var item = _FollowedItems.Find(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            item.Title = FollowedItem.Title;
            item.Type = FollowedItem.Type;
            item.BeFollowed = FollowedItem.BeFollowed;
            item.EndDate = FollowedItem.EndDate;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Supprimer(int id)
        {
            var item = _FollowedItems.Find(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            _FollowedItems.Remove(item);
            return NoContent();
        }
    }
}