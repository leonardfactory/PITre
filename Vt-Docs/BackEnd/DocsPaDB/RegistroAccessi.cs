﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DocsPaVO.filtri;
using log4net;

namespace DocsPaDB
{
    public class RegistroAccessi : DBProvider
    {
        private ILog logger = LogManager.GetLogger(typeof(RegistroAccessi));

        public DataSet GetDataSetRegistroAccessi(List<FiltroRicerca> filters)
        {
            logger.Debug("BEGIN");

            DataSet dataSet = null;

            try
            {
                DocsPaUtils.Query query = DocsPaUtils.InitQuery.getInstance().getQuery("S_REGISTRO_ACCESSI");
                this.SetFilters(query, filters);

                string command = query.getSQL();
                logger.Debug("QUERY - " + command);

                if (!this.ExecuteQuery(out dataSet, command))
                    throw new Exception(this.LastExceptionMessage);

            }
            catch(Exception ex)
            {
                dataSet = null;
                logger.DebugFormat("Errore in GetDataSetRegistroAccessi.\r\n{0}\r\n{1}", ex.Message, ex.StackTrace);
            }

            logger.Debug("END");

            return dataSet;
        }

        private void SetFilters(DocsPaUtils.Query query, List<FiltroRicerca> filters)
        {
            logger.Debug("BEGIN");
            // id amministrazione
            query.setParam("id_amm", filters.Where(f => f.argomento == "id_amm").FirstOrDefault().valore);

            // tipologia
            query.setParam("filtro_tipologia", String.Format("UPPER(VAR_DESC_FASC)=UPPER('{0}')", filters.Where(f => f.argomento == "tipologia").FirstOrDefault().valore));

            // stato del fascicolo
            String folderStatus = filters.Where(f => f.argomento == "stato").FirstOrDefault().valore;
            String statusFilter = string.Empty;
            if (folderStatus == "O")
            {
                statusFilter = "AND A.CHA_STATO='A'";
            }
            else if (folderStatus == "C")
            {
                statusFilter = "AND A.CHA_STATO='C'";
            }
            query.setParam("filtro_stato", statusFilter);

            // data di creazione
            String dateFilter = string.Empty;
            String creationDateInterval = filters.Where(f => f.argomento == "data_creazione").FirstOrDefault().valore;
            String creationDateFrom = filters.Where(f => f.argomento == "data_creazione_da").FirstOrDefault().valore;
            String creationDateTo = filters.Where(f => f.argomento == "data_creazione_a").FirstOrDefault().valore;

            if (creationDateInterval == "0")
            {
                // Valore singolo
                if (!string.IsNullOrEmpty(creationDateFrom))
                {
                    dateFilter = String.Format("AND A.DTA_CREAZIONE >={0} AND A.DTA_CREAZIONE <={1}",
                        DocsPaDbManagement.Functions.Functions.ToDateBetween(creationDateFrom, true),
                        DocsPaDbManagement.Functions.Functions.ToDateBetween(creationDateFrom, false));
                }
            }
            if (creationDateInterval == "1")
            {
                // Intervallo
                if (!string.IsNullOrEmpty(creationDateFrom))
                {
                    dateFilter = "AND A.DTA_CREAZIONE >= " + DocsPaDbManagement.Functions.Functions.ToDateBetween(creationDateFrom, true);
                }
                if (!string.IsNullOrEmpty(creationDateTo))
                {
                    dateFilter = dateFilter + " AND A.DTA_CREAZIONE <= " + DocsPaDbManagement.Functions.Functions.ToDateBetween(creationDateTo, false);
                }
            }
            query.setParam("filtro_data", dateFilter);

            if(dbType.ToUpper() == "SQL")
                query.setParam("dbUser", DocsPaDbManagement.Functions.Functions.GetDbUserSession());

            logger.Debug("END");
        }
    }
}