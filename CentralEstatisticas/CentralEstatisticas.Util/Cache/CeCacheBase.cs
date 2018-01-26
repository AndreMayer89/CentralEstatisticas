﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CentralEstatisticas.Util.Cache
{
    public abstract class CeCacheBase
    {
        public TTipoItem ExecutarFuncaoBusca<TTipoItem>(Delegate funcaoBuscaBanco, int duracaoMinutos, params object[] parametros)
        {
            string chaveCache = GerarChaveParametroCache(funcaoBuscaBanco.Method.Name, parametros);
            if (!ConfigCentralEstatisticas.Cache.Desabilitar && ContemItem(chaveCache))
            {
                return ObterItem<TTipoItem>(chaveCache);
            }

            object item = funcaoBuscaBanco.DynamicInvoke(parametros);
            TTipoItem retorno = (TTipoItem)item;

            AdicionarItem(chaveCache, retorno, duracaoMinutos);

            return retorno;
        }

        public void AtualizarItem<TTipoItem>(TTipoItem item, Delegate funcaoBuscaBanco, int duracaoMinutos, params object[] parametros)
        {
            string chaveCache = GerarChaveParametroCache(funcaoBuscaBanco.Method.Name, parametros);
            if (ContemItem(chaveCache))
            {
                RemoverItem(chaveCache);
            }
            AdicionarItem(chaveCache, item, duracaoMinutos);
        }

        public void RemoverItemCache(string chave)
        {
            RemoverItem(chave);
        }

        public List<string> ObterChavesEmCache()
        {
            return ObterChaves();
        }

        #region Métodos Abstratos

        public abstract bool ContemItem(string chaveItem);

        public abstract void LimparCache();

        protected abstract void RemoverItem(string chaveItem);

        protected abstract TTipoItem ObterItem<TTipoItem>(string chaveItem);

        public abstract void AdicionarItem<TTipoItem>(string chaveItem, TTipoItem item, int duracaoMinutos);

        protected abstract List<string> ObterChaves();

        #endregion

        #region Métodos Privados

        private static string GerarChaveParametroCache(string nomeFuncao, params object[] parametros)
        {
            StringBuilder chaveGerada = new StringBuilder();
            chaveGerada.Append(nomeFuncao).Append("__");
            GerarChaveParametrosCache(parametros, chaveGerada);
            return chaveGerada.ToString();
        }

        private static void GerarChaveParametrosCache(System.Collections.ICollection parametros, StringBuilder chaveGerada)
        {
            foreach (var parametro in parametros)
            {
                GerarChaveParametroCache(parametro, chaveGerada);
            }
        }

        private static void GerarChaveParametroCache(object parametro, StringBuilder chaveGerada)
        {
            if (parametro == null)
            {
                chaveGerada.Append("NULL__");
            }
            else
            {
                var parametroArray = parametro as System.Collections.ICollection;
                if (parametroArray != null)
                {
                    chaveGerada.Append("____INICIO_ARRAY____");
                    GerarChaveParametrosCache(parametroArray, chaveGerada);
                    chaveGerada.Append("____FIM_ARRAY____");
                }
                else
                {
                    chaveGerada.Append(parametro.ToString()).Append("__");
                }
            }
        }

        #endregion
    }
}
