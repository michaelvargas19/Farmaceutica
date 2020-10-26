using serverdespacho.Entidades;
using serverdespacho.Peristencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Negocio
{
    public class ConfiguracionNegocio
    {
        private readonly DBContext DBContext;

        public ConfiguracionNegocio(DBContext dbContext)
        {
            this.DBContext = dbContext;
        }

        public List<Departamento> getDepartamentos(){

            return DBContext.Departamentos.ToList();

        }

        public List<Municipio> getMunicipios()
        {

            return DBContext.Municipios.ToList();

        }

        public List<EstadoDespachos> getEstadosDespachos()
        {

            return DBContext.EstadosDespachos.ToList();

        }

        public List<EstadoOfertas> getEstadosOfertas()
        {

            return DBContext.EstadosOfertas.ToList();

        }

    }
}
