using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public enum OrderStatus
    {
        In,
        Partial,
        Completed,
        Paid,
        Walked
    }

    public enum CopyOfOrderStatus
    {
        In,
        Partial,
        Completed,
        Paid,
        Walked
    }

    public enum CopyOfCopyOfOrderStatus
    {
        In,
        Partial,
        Completed,
        Paid,
        Walked
    }

    public enum CopyOfCopyOfCopyOfOrderStatus
    {
        In,
        Partial,
        Completed,
        Paid,
        Walked
    }

    public enum CopyOfCopyOfCopyOfCopyOfOrderStatus
    {
        In,
        Partial,
        Completed,
        Paid,
        Walked
    }
}