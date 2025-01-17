﻿using System;
using System.Collections.Generic;
using FluentValidation.Results;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Domain
{
    public class Voucher : Entity
    {
        public string Codigo { get; private set; }
        public decimal? PercentualDesconto { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public int Quantidade { get; private set; }
        public TipoDescontoVoucher TipoDescontoVoucher { get; private set; }
        public DateTime DataValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizado { get; private set; }

        // EF Rel.
        public ICollection<Pedido> Pedidos { get; set; }

        public Voucher(string codigo, decimal? percentualDesconto, decimal? valorDesconto, int quantidade,
            TipoDescontoVoucher tipoDescontoVoucher, DateTime dataValidade, bool ativo, bool utilizado)
        {
            Codigo = codigo;
            PercentualDesconto = percentualDesconto;
            ValorDesconto = valorDesconto;
            Quantidade = quantidade;
            TipoDescontoVoucher = tipoDescontoVoucher;
            DataValidade = dataValidade;
            Ativo = ativo;
            Utilizado = utilizado;
        }

        public ValidationResult ValidarSeAplicavel()
        {
            return new VoucherAplicavelValidation().Validate(this);
        }
    }
}