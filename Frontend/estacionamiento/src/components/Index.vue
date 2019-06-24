<template>
    <v-container mt-0>
        
        <v-toolbar flat height="85" >
            <v-layout align-start justify-space-around row>
                
                <v-flex md4>
                    
                    <v-text-field v-model="names" label="Cajero" readonly></v-text-field>
                    
                    
                </v-flex>
                <v-flex md4>
                    <v-text-field v-model="estanombre" label="Estacionamiento" readonly></v-text-field>
                </v-flex>
            </v-layout>
        </v-toolbar>
        <v-container fluid grid-list-md>
            <v-layout row wrap>
                <app-nuevo v-if="dialog" dialog="true" :cajero=cajero :espacio=espacioselect @fin="guardado()"></app-nuevo>
                
                <v-flex v-for="item in espacios" :key="item.id" md4>
                    
                    <v-card v-if="!item.disponible">
                            <div  style="text-align:center" >
                                <h3 class=" pa-3 headline   " style="color:black" >{{item.espacioId}}</h3>
                            </div>
                        
                        <v-card-text style="background-color: lightskyblue; text-align:center" >
                            <v-icon style="color: red; font-size:80px"  >
                                directions_car
                            </v-icon>
                        </v-card-text>
                        
                      <v-layout align-start justify-space-around row >
                          
                            <v-card-actions>
                                <v-flex> 
                                    <v-btn flat color="orange">Cobrar</v-btn>
                                </v-flex>
                            </v-card-actions>
                       
                        </v-layout>
                    </v-card>

                    <v-card v-else>
                        
                            <div  style="text-align:center" >
                                <h3 class=" pa-3 headline   " style="color:black" >{{item.espacioId}}</h3>
                            </div>
                        
                        <v-card-text style="background-color: lightskyblue; text-align:center" >
                            <v-icon style="color: green; font-size:80px"  >
                                directions_car
                            </v-icon>
                        </v-card-text>
                        
                      <v-layout align-start justify-space-around row >
                          
                            <v-card-actions>
                                <v-flex> 
                                    <v-btn flat color="blue" @click="GenerarIngreso(item.espacioId)" >Generar</v-btn>
                                </v-flex>
                            </v-card-actions>
                       
                        </v-layout>
                    </v-card> 

                </v-flex>
            </v-layout>
        </v-container>
    </v-container>

</template>




<script>
import axios from 'axios'
import Nuevo from './NuevoIngreso'
export default {
    components :{
        'app-nuevo':Nuevo
    },
    data() {
        return {
                dialog:false,
                espacios:[],
                estacionamiento:[],
                cajero:"", 
                espacioselect:"",
                names:" ",
                estanombre:" "   
        }
    },
    created() {
        this.loadCajeros();
        this.loadEstacionamiento();
        this.loadEspacios();
       
    },
    methods: {
        loadCajeros(){
            let me=this;
            var aux=[];
            axios.get("api/Cajero").then(function (response) {
                aux=response.data;
                me.cajero=aux[0];
                me.names=me.cajero.nombreCajero+" "+me.cajero.apellidoCajero
                
            }).catch(function(error) {
          console.log(error);
            });
        },
        loadEspacios(){
            let me=this;
            var aux=[];
           
            axios.get("api/Estacionamiento/"+"1").then(function (response) {
                aux=response.data;
                aux.espacios.map((t)=>{
                    me.espacios.push(t)
                })
                console.log("hello");
            }).catch(function(error) {
          console.log(error,"jee");
        })
        },
        loadEstacionamiento(){
            let me=this;
            var aux=[];
            axios.get("api/Estacionamiento/"+"1").then(function (response) {
                aux=response.data;
                me.estacionamiento=aux;
                me.estanombre=me.estacionamiento.nombre_Estacionamiento;
            }).catch(function(error) {
            console.log(error,aux);
            });
        },
        GenerarIngreso(id){
            
            this.dialog=true;
            
            this.espacioselect=id;
            
        },
        guardado(){
                this.dialog=false;
                this.espacios=[];
                this.loadEspacios();
                vm.$forceUpdate();
        }
    },
}
</script>
