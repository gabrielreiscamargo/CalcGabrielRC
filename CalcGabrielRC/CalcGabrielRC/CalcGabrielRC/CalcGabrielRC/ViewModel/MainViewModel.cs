using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalcGabrielRC.ViewModel
{
  


        public enum Operacao
        {
            Soma,
            Subtracao,
            Multiplicacao,
            Divisao
        }

        public class MainViewModel : INotifyPropertyChanged
        {
            #region Eventos
            public event PropertyChangedEventHandler PropertyChanged;
            #endregion

            #region Atributos
            Operacao? _operacao;
            decimal _numero1, _numero2, _visor;
            #endregion

            #region Propriedades
            public decimal Visor
            {
                get { return _visor; }
                set
                {
                    _visor = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Visor))
                    );
                }
            }
            #endregion

            #region Construtores
            public MainViewModel()
            {
                _numero1 = 0;
                _numero2 = 0;
                Visor = 0;

                InsereNumeroCommand = new Command<string>(InsereNumero);
                LimpaTudoCommand = new Command(LimpaTudo);
                InsereOperacaoCommand = new Command<string>(InsereOperacao);
                RealizaOperacaoCommand = new Command(RealizaOperacao);
            }
            #endregion

            #region Comandos
            public ICommand RealizaOperacaoCommand { get; }
            public ICommand InsereNumeroCommand { get; }
            public ICommand LimpaTudoCommand { get; }
            public ICommand InsereOperacaoCommand { get; }
            #endregion

            #region Métodos
            private void RealizaOperacao()
            {
                switch (_operacao)
                {
                    case Operacao.Soma:
                        _numero1 = _numero1 + _numero2;
                        break;
                    case Operacao.Subtracao:
                        _numero1 = _numero1 - _numero2;
                        break;
                    case Operacao.Multiplicacao:
                        _numero1 = _numero1 * _numero2;
                        break;
                    case Operacao.Divisao:
                        try
                        {
                            _numero1 = _numero1 / _numero2;
                        }
                        catch
                        {
                            _numero1 = 0;
                        }
                        break;
                    default:
                        return;

                }

                Visor = _numero1;
                _numero2 = 0;
                _operacao = null;
            }

            private void LimpaTudo()
            {
                _numero1 = 0;
                _numero2 = 0;
                _operacao = null;
                Visor = 0;
            }

            private void InsereOperacao(string operacao)
            {
                switch (operacao)
                {
                    case "+":
                        _operacao = Operacao.Soma;
                        break;
                    case "-":
                        _operacao = Operacao.Subtracao;
                        break;
                    case "*":
                        _operacao = Operacao.Multiplicacao;
                        break;
                    case "/":
                        _operacao = Operacao.Divisao;
                        break;
                }
            }

            private void InsereNumero(string numeroInserido)
            {
                if (_operacao == null)
                {
                    _numero1 = _numero1 * 10 + Convert.ToDecimal(numeroInserido);
                    Visor = _numero1;
                }
                else
                {
                    _numero2 = _numero2 * 10 + Convert.ToDecimal(numeroInserido);
                    Visor = _numero2;
                }
            }
            #endregion
        }
    }

