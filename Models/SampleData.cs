using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ReclamaPoa2013.Models;

namespace ReclamaPoa2013.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<ReclamaPoaEntities>
    {
        protected override void Seed(ReclamaPoaEntities context)
        {
            var categorias = AddCategorias(context);
            var bairros = AddBairros(context);

            context.SaveChanges();
        }

        private static List<Bairro> AddBairros(ReclamaPoaEntities context)
        {
            var bairros = new List<Bairro>
            {
                new Bairro { Nome = "Agronomia"},  
				new Bairro { Nome = "Anchieta "},  
				new Bairro { Nome = "Arquipélago"},
				new Bairro { Nome = "Auxiliadora"},
				new Bairro { Nome = "Azenha"},      
				new Bairro { Nome = "Bela Vista"},  
				new Bairro { Nome = "Belém Novo"},  
				new Bairro { Nome = "Belém Velho "},
				new Bairro { Nome = "Boa Vista"},   
				new Bairro { Nome = "Bom Fim"},     
				new Bairro { Nome = "Bom Jesus"},   
				new Bairro { Nome = "Camaquã"},
				new Bairro { Nome = "Campo Novo"},                           
				new Bairro { Nome = "Cascata"},                              
				new Bairro { Nome = "Cavalhada"},                            
				new Bairro { Nome = "Cel. Aparício Borges"},                 
				new Bairro { Nome = "Centro Histórico"},                     
				new Bairro { Nome = "Chácara das Pedras"},                   
				new Bairro { Nome = "Chapéu do Sol"},                        
				new Bairro { Nome = "Cidade Baixa"},                         
				new Bairro { Nome = "Cristal "},                             
				new Bairro { Nome = "Cristo Redentor"},                      
				new Bairro { Nome = "Espírito Santo"},                       
				new Bairro { Nome = "Farrapos"},                             
				new Bairro { Nome = "Farroupilha"},                          
				new Bairro { Nome = "Floresta"},                             
				new Bairro { Nome = "Glória"},                               
				new Bairro { Nome = "Guarujá"},                              
				new Bairro { Nome = "Higienópolis"},                         
				new Bairro { Nome = "Hípica"},                               
				new Bairro { Nome = "Humaitá"},                              
				new Bairro { Nome = "Independência"},                        
				new Bairro { Nome = "Ipanema "},                             
				new Bairro { Nome = "Jardim Botânico"},                      
				new Bairro { Nome = "Jardim Carvalho"},                      
				new Bairro { Nome = "Jardim do Salso"},                      
				new Bairro { Nome = "Jardim Floresta"},
				new Bairro { Nome = "Jardim Isabel"},                        
				new Bairro { Nome = "Jardim Itu-Sabará"},                    
				new Bairro { Nome = "Jardim Lindóia"},                       
				new Bairro { Nome = "Jardim São Pedro"},                     
				new Bairro { Nome = "Lageado"},                              
				new Bairro { Nome = "Lami"},                                 
				new Bairro { Nome = "Lomba do Pinheiro"},                    
				new Bairro { Nome = "Marcílio Dias"},                        
				new Bairro { Nome = "Mário Quintana"},                       
				new Bairro { Nome = "Medianeira"},                           
				new Bairro { Nome = "Menino Deus"},                          
				new Bairro { Nome = "Moinhos de Vento"},                     
				new Bairro { Nome = "Mont Serrat"},                          
				new Bairro { Nome = "Navegantes"},                           
				new Bairro { Nome = "Nonoai"},                               
				new Bairro { Nome = "Partenon"},                             
				new Bairro { Nome = "Passo da Areia"},                       
				new Bairro { Nome = "Pedra Redonda"},                        
				new Bairro { Nome = "Petrópolis"},                           
				new Bairro { Nome = "Ponta Grossa"},                         
				new Bairro { Nome = "Praia de Belas"},                       
				new Bairro { Nome = "Restinga"},                             
				new Bairro { Nome = "Rio Branco"},                           
				new Bairro { Nome = "Rubem Berta"},                          
				new Bairro { Nome = "Santa Cecília"},                        
				new Bairro { Nome = "Santa Maria Goretti"},                  
				new Bairro { Nome = "Santa Tereza"},                         
				new Bairro { Nome = "Santana"},                              
				new Bairro { Nome = "Santo Antônio"},                        
				new Bairro { Nome = "São Geraldo"},                          
				new Bairro { Nome = "São João"},                             
				new Bairro { Nome = "São José"},                             
				new Bairro { Nome = "São Sebastião"},                        
				new Bairro { Nome = "Sarandi"},                              
				new Bairro { Nome = "Serraria"},                             
				new Bairro { Nome = "Teresópolis"},                          
				new Bairro { Nome = "Três Figueiras"},                       
				new Bairro { Nome = "Tristeza"},                             
				new Bairro { Nome = "Vila Assunção"},                        
				new Bairro { Nome = "Vila Conceição"},                       
				new Bairro { Nome = "Vila Ipiranga"},                        
				new Bairro { Nome = "Vila Jardim"},                          
				new Bairro { Nome = "Vila João Pessoa"},                     
				new Bairro { Nome = "Vila Nova"},			
				
            };
            bairros.ForEach(s => context.Bairros.Add(s));
            context.SaveChanges();
            return bairros;
        }

        private static List<Categoria> AddCategorias(ReclamaPoaEntities context)
        {
            var categorias = new List<Categoria>
            {
                new Categoria { Nome = "Árvore", Descricao = "Árvores ou galhos caídos, poda necessária, poda irregular"},
                new Categoria { Nome = "Água e Esgoto", Descricao = "Falta de água, esgoto a céu aberto, vazamentos, bueiros entupidos" },
                new Categoria { Nome = "Alagamento", Descricao = "Alagamentos, pontos críticos" },
                new Categoria { Nome = "Segurança", Descricao = "Assaltos, falta de segurança" },
                new Categoria { Nome = "Acessibilidade", Descricao = "Falta de acessibilidade, rampas e calçadas irregulares, obstáculos sobre o piso de orientação, equipamentos de acessibilidade em mau estado" },
                new Categoria { Nome = "Buraco", Descricao="Ruas ou calçadas esburacadas" },
                new Categoria { Nome = "Calçadas", Descricao="Calçada obstruída, buracos, calçada inexistente" },
                new Categoria { Nome = "Ciclovia", Descricao="Falta de sinalização, má conservação, necessidade de ciclovia" },
                new Categoria { Nome = "Lixo", Descricao="Lixo ou entulho acumulado" },
                new Categoria { Nome = "Mato", Descricao="Mato alto necessitando corte" },
                new Categoria { Nome = "Pichação", Descricao="Pichações em muros ou fachadas" },
                new Categoria { Nome = "Poluição do Ar", Descricao="Poluição do ar, fumaça de queimadas, cheiro de produtos químicos" },
                new Categoria { Nome = "Poluição Sonora", Descricao="Música alta, barulho, buzinas" },
                new Categoria { Nome = "Trânsito", Descricao="Congestionamentos frequentes, ocorrência de rachas, pontos críticos" },
                new Categoria { Nome = "Outros", Descricao="Outras reclamações" },
            };

            categorias.ForEach(s => context.Categorias.Add(s));
            context.SaveChanges();
            return categorias;
        }
    }
}