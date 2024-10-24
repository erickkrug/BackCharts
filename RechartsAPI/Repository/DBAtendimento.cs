using Dapper;

namespace RechartsAPI.Repository
{
    public class DBAtendimento
    {
        public static IEnumerable<Models.AtendimentoModel> GetData(Models.AtdParametroModel data)
        {
            try
            {
                var query = @"select 
	                                count(1) as 'TotalAtendimento', 
	                                mtvch.moch_nm_motivoChamada as 'MotivoChamadaNome', 
	                                serv.serv_tx_descricao as 'Servico' 
                                from 
	                                atendimento atd 
                                INNER JOIN motivo_chamada mtvch on atd.moch_cd_motivoChamada = mtvch.moch_cd_motivoChamada
                                INNER JOIN servico serv on serv.Id = mtvch.serv_cd_servico
                                where 
	                                aten_dt_atendimento between @datainicio and @datafim
	                                and atd.empr_cd_empresa = @empresaid
	                                and serv.Id in @servico
                                group by 
	                                serv.serv_tx_descricao, 
	                                mtvch.moch_nm_motivoChamada  
                                order by
                                    serv.serv_tx_descricao,
                                    mtvch.moch_nm_motivoChamada";
                var result = Repository.SQL.Connection().Query<Models.AtendimentoModel>(query, new
                {
                    empresaid = data.EmpresaId,
                    servico = data.Servicos,
                    datainicio = data.DataInicio,
                    datafim = data.DataFim
                }).ToList();


                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
