using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleEFCoreDataLayer.Entities;

namespace SimpleEFCoreDataLayer.ValueGenerator
{
    //تولید کد رهگیری
    public class TrackingCodeValueGenerator : Microsoft.EntityFrameworkCore.ValueGeneration.ValueGenerator<string>

    {
        public override string Next(EntityEntry entry)
        {
            var rnd= new Random();
            
            var entity =(Member) entry.Entity;
            //or var entity =(BaseEntity<int>) entry.Entity;

            return entity.Id+ rnd.Next(11111, 9999999).ToString();
        }

        //آیا این مقدار قراره موقت باشه؟ یا دائمی در سمت دیتابیس ذخیره شود؟
        public override bool GeneratesTemporaryValues { get; } = false;
    }


    //public class MemberCountValueGenerator : Microsoft.EntityFrameworkCore.ValueGeneration.ValueGenerator<int>
    //{
    //    public override int Next(EntityEntry entry)
    //    {
    //        var entity = (Gym)entry.Entity;
    //       return entity.Employees.Count()++;
    //    }

    //    public override bool GeneratesTemporaryValues { get; }
    //}
}
