<template>
    <v-container mt-0>
        <v-layout row wrap >
            <v-flex xs12>
                <v-form ref="form" >
                    <v-layout rpw wrap>
                        <v-flex xs6>
                            <v-text-field 
                                v-model="placa"
                                :counter="7"
                                :rules="Placarules"
                                label="Placa"  >
                            </v-text-field>
                        </v-flex>
                        <v-flex xs4 justify-center >
                            <v-btn color="green accent-3"  @click.native="Buscar"   >
                                Buscar
                            </v-btn>
                        </v-flex>
                    </v-layout>
                </v-form>

            </v-flex>
        </v-layout>
        <v-container>
            <v-layout justify-center fill-height>
                <div v-if="mostrar">
                    <v-card class="mx-auto"  >
                        <v-card-title>
                            <v-icon class="mr-3" style="color: red; font-size:50px">directions_car</v-icon>
                            <span>
                            <span class="title font-weight-light">Mi Auto</span>
                        </span>
                        </v-card-title>
                        
                        <v-card-text>
                            <v-container grid-list-md>
                                <v-layout wrap>
                                    <v-flex xs12 sm12 md12>
                                        <v-text-field v-model="placasel" placeholder="Placa" label="Placa" readonly></v-text-field>
                                    </v-flex>
                                    <v-flex xs12 sm12 md12>
                                        <v-text-field v-model="espacioid" placeholder="Espacio" label="Espacio" readonly></v-text-field>
                                    </v-flex>
                                    <v-flex xs12 sm12 md12>
                                        <v-text-field v-model="monto" placeholder="Monto" label="Monto" readonly></v-text-field>
                                    </v-flex>
                                    <v-flex xs12 sm12 md12>
                                        <v-text-field v-model="tiempo" placeholder="Tiempo" label="Tiempo" readonly></v-text-field>
                                    </v-flex>
                                    <v-flex xs12 sm12 md12>
                                        <v-text-field v-model="tipoveh" placeholder="Vehiculo" label="Tipo" readonly></v-text-field>
                                    </v-flex>
                                   
                                </v-layout>
                            </v-container>
                        </v-card-text>
                    </v-card>
                </div>
               
                
            </v-layout>
        </v-container>
    </v-container>
</template>




<script>
import axios from "axios";
export default {
    data() {
    return {
      
      Placarules: [
        v => !!v || 'Ingrese su placa',
        v => (v && v.length === 7 && /.+-.+/.test(v)) || 'Ingrese una placa válida',
        
        
        
      ],
      mostrar: true,
      ingreso:"",
      placa:"",
      placasel:"",
      espacioid:"",
      tiempo:"",
      monto:"",
      tipoveh:""
    };
    
  },
  
  methods: {
        Buscar(){
            if (this.$refs.form.validate()) {
               let me = this;
                axios
                    .get("api/Ingreso/placa/"+me.placa)
                    .then(function(response) {
                    me.ingreso = response.data;
                    me.placasel=me.ingreso.placa;
                    me.espacioid=me.ingreso.espacio.espacioId;
                    me.tipoveh=me.ingreso.tarifa.tipoVehiculo;
                    me.$refs.form.reset();
                    me.mostrar=true;
                    me.Monto();
                    
                    })
                    .catch(function(error) {
                    console.log(error);
                    });
            
            
             
            }
            
            

        },
        

        Monto(){
            
            var monto="";
            var duracion= new Date(this.ingreso.hInicio);
            var hoy = new Date(Date.now());
           
            duracion=Math.abs(hoy-duracion)/1000;
            
            var parte_entera=Math.floor(duracion/ 60 / 60 % 24);
            parte_entera=Math.trunc(parte_entera);
            var minutos=Math.trunc(duracion/ 60 % 60);
            if(minutos<10){
                minutos="0"+minutos;
            }
            if (parte_entera<10) {
                this.tiempo="0"+parte_entera+" : "+minutos;
            }
            else{
                this.tiempo=parte_entera+" : "+minutos;
            }
            if (minutos<15) {
                monto=this.ingreso.tarifa.monto*(parte_entera+1);
            }else{
                monto=this.ingreso.tarifa.monto*parte_entera;
            }
            
            this.tiempo=this.tiempo+" horas";

            this.monto="S/. "+monto;
            
        }
    }
}
</script>