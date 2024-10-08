using FluentAssertions;
using Xunit;
using System;
using b3digitas.Domain.Entities;

namespace b3digitas.tests
{
    public class DomianUnitTest1
    {
        [Fact]
        public void Created_Order_price_empty1()
        {
            Action action = () => new Order("0.2359", "", "B", "BTC", "USD");
            action.Should().NotThrow<b3digitas.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact]
        public void Created_Order_type_empty()
        {
            Action action = () => new Order("0.2359", "658089", "C", "BTC", "USD");
            action.Should().NotThrow<b3digitas.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void Created_Order_symbol_empty()
        {
            Action action = () => new Order("0.2359", "658089", "A", "", "USD");
            action.Should().NotThrow<b3digitas.Domain.Validation.DomainExceptionValidation>();
        }



        [Fact]
        public void Created_Quote_operation()
        {
            Action action = () => new Quote("C", "BTC", "10");
            action.Should().NotThrow<b3digitas.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact]
        public void Created_Quote_coin()
        {
            Action action = () => new Quote("12503", "AAA", "10");
            action.Should().NotThrow<b3digitas.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void Created_Quote_quantity()
        {
            Action action = () => new Quote("12503", "AAA", " ");
            action.Should().NotThrow<b3digitas.Domain.Validation.DomainExceptionValidation>();
        }

    }
}
