--------------------------------------------------------
--  Constraints for Table DPA_TRASM_UTENTE
--------------------------------------------------------

  ALTER TABLE "ITCOLL_6GIU12"."DPA_TRASM_UTENTE" MODIFY ("CHA_VISTA_DELEGATO" NOT NULL ENABLE);
 
  ALTER TABLE "ITCOLL_6GIU12"."DPA_TRASM_UTENTE" MODIFY ("CHA_ACCETTATA_DELEGATO" NOT NULL ENABLE);
 
  ALTER TABLE "ITCOLL_6GIU12"."DPA_TRASM_UTENTE" MODIFY ("CHA_RIFIUTATA_DELEGATO" NOT NULL ENABLE);
 
  ALTER TABLE "ITCOLL_6GIU12"."DPA_TRASM_UTENTE" ADD PRIMARY KEY ("SYSTEM_ID") ENABLE;