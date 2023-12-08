using EstevezGayosoRosanaTarea4.Database.Models;

namespace EstevezGayosoRosanaTarea4
{
    public static class CalcularGanador
    {
        public static Batalla Simulador(Equipo equipoUno, Equipo equipoDos)
        {
            var batalla = new Batalla
            {
                EquipoUno = equipoUno,
                EquipoDos = equipoDos,
                Combates = new List<Combate>(),              
            };

            for (int i = 0; i < batalla.EquipoUno.Pokemons.Count; i++)
            {
                var combate = new Combate
                {
                    pokemonUno = batalla.EquipoUno.Pokemons[i],
                    pokemonDos = batalla.EquipoDos.Pokemons[i],
                };
                batalla.Combates.Add(combate);
            }

            foreach (var combate in batalla.Combates)
            {
                combate.pokemonGanador = GetGanador(combate.pokemonUno, combate.pokemonDos, equipoUno, equipoDos);
            }
            
            return batalla;

        }

        private static Pokemon GetGanador(Pokemon pokemonUno, Pokemon PokemonDos,Equipo equipoUno, Equipo equipoDos)
        {
            var pokemonUnoGana = false;
            var pokemonDosGana = false;
            
            
            foreach (var tipoUno in pokemonUno.Tipos)
            {
                foreach (var tipoDos in PokemonDos.Tipos)
                {
                    if (quienEsMasFuerte(tipoUno, tipoDos))
                    {
                        pokemonUnoGana = true;
                        break;
                    }
                }

            }
            foreach (var tipoDos in PokemonDos.Tipos)
            {
                foreach (var tipoUno in pokemonUno.Tipos)
                {
                    if (quienEsMasFuerte(tipoDos, tipoUno))
                    {
                        pokemonDosGana = true;
                        break;
                    }
                }

            }
            if (pokemonUnoGana && !pokemonDosGana)
            {
                equipoUno.ContadorVictorias++;
                
                return pokemonUno;
            }
            else if (!pokemonUnoGana && pokemonDosGana)
            {
                equipoDos.ContadorVictorias++;
                return PokemonDos;
            }
            else
            {
                if (pokemonUno.Peso + pokemonUno.Altura > PokemonDos.Peso + PokemonDos.Altura)
                {
                    equipoUno.ContadorVictorias++;
                    return pokemonUno;
                }
                else
                {
                    equipoDos.ContadorVictorias++;
                    return PokemonDos;
                }
            }

        }
        public static Equipo DeterminarEquipoGanador(Equipo equipoUno, Equipo equipoDos)
        {
            if(equipoUno.ContadorVictorias > equipoDos.ContadorVictorias)
            {
                equipoUno.ContadorVictorias = 0;
                equipoDos.ContadorVictorias = 0;
                return equipoUno;
                
            }
            else if (equipoUno.ContadorVictorias < equipoDos.ContadorVictorias)
            {
                equipoUno.ContadorVictorias = 0;
                equipoDos.ContadorVictorias = 0;
                return equipoDos;
            }
            else
            {
                equipoUno.ContadorVictorias = 0;
                equipoDos.ContadorVictorias = 0;
                return null;
            }
            
            
        }
        private static bool quienEsMasFuerte(Tipo tipo1, Tipo tipo2)
        {
            switch (tipo1.nombre)
            {
                case "Fuego":
                    return tipo2.nombre == "Planta" || tipo2.nombre == "Hielo" || tipo2.nombre == "Acero" || tipo2.nombre == "Bicho" || tipo2.nombre == "Fuego";

                case "Agua":
                    return tipo2.nombre == "Fuego" || tipo2.nombre == "Hielo" || tipo2.nombre == "Acero" || tipo2.nombre == "Agua";

                case "Planta":
                    return tipo2.nombre == "Agua" || tipo2.nombre == "Eléctrico" || tipo2.nombre == "Tierra" || tipo2.nombre == "Planta";

                case "Eléctrico":
                    return tipo2.nombre == "Agua" || tipo2.nombre == "Volador";

                case "Hielo":
                    return tipo2.nombre == "Planta" || tipo2.nombre == "Tierra";

                case "Volador":
                    return tipo2.nombre == "Planta" || tipo2.nombre == "Lucha" || tipo2.nombre == "Bicho";
                case "Tierra":
                    return tipo2.nombre == "Fuego" || tipo2.nombre == "Eléctrico";

                case "Lucha":
                    return tipo2.nombre == "Normal" || tipo2.nombre == "Hielo" || tipo2.nombre == "Roca" || tipo2.nombre == "Acero" || tipo2.nombre == "Siniestro";
                case "Veneno":
                    return tipo2.nombre == "Planta" || tipo2.nombre == "Bicho" || tipo2.nombre == "Lucha" || tipo2.nombre == "Veneno";
                case "Roca":
                    return tipo2.nombre == "Fuego" || tipo2.nombre == "Hielo" || tipo2.nombre == "Volador" || tipo2.nombre == "Bicho";
                case "Bicho":
                    return tipo2.nombre == "Psíquico" || tipo2.nombre == "Siniestro" || tipo2.nombre == "Planta";
                case "Fantasma":
                    return tipo2.nombre == "Psíquico" || tipo2.nombre == "Fantasma";

                case "Acero":
                    return tipo2.nombre == "Hielo" || tipo2.nombre == "Roca" || tipo2.nombre == "Psíquico" || tipo2.nombre == "Acero" || tipo2.nombre == "Bicho" || tipo2.nombre == "Dragón" || tipo2.nombre == "Normal" || tipo2.nombre == "Planta" || tipo2.nombre == "Volador";
                case "Psíquico":
                    return tipo2.nombre == "Lucha" || tipo2.nombre == "Psíquico";

                default:

                    return false;
            }

        }
    }
}
