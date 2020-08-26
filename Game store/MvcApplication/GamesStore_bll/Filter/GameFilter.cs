using GamesStore_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GameesStore_client.Filter
{
    public class GameFilter
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public Expression<Func<Game, bool>> Predicate { get; set; }
    }
}