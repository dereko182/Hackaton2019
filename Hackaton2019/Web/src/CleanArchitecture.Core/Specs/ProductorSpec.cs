using CleanArchitecture.Core.Entities;
using System;
using System.Linq.Expressions;

namespace CleanArchitecture.Core.Specs
{
    public class ProductorSpec : BaseSpecification<Productor>
    {
        public ProductorSpec(Expression<Func<Productor, bool>> criteria) : base(criteria)
        {
            AddInclude(x => x.Ranchos);
            AddInclude("Ranchos.Lotes");
        }
    }

    public class RanchoSpec : BaseSpecification<Rancho>
    {
        public RanchoSpec() : base(x => true)
        {
            AddInclude(x => x.Lotes);
            AddInclude("Lotes.Parcelas");
        }
    }

    public class ProductosSpec : BaseSpecification<Producto>
    {
        public ProductosSpec() : base(x => true)
        {
            AddInclude(x => x.Proveedor);
        }
    }
}
