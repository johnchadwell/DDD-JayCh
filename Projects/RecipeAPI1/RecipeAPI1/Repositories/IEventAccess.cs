using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IEventRepository
    {
        int NewEvent(Event c);
        Event GetEvent(int id);
        //IEnumerable<Event> GetAllEvents();
    }
    public class EventRepository : IEventRepository
    {
        RecipeContext ctx;
        public EventRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewEvent(Event c)
        {
            ctx.Events.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public Event GetEvent(int id)
        {
            Event c = ctx.Events.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
