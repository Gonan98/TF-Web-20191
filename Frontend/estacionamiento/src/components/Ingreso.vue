<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Ingresos Admin</v-toolbar-title>
        <v-divider class="mx-2" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-text-field
          class="text-xs-center"
          v-model="search"
          append-icon="search"
          label="Búsqueda"
          single-line
          hide-details
        ></v-text-field>
        <v-spacer></v-spacer>
        

        <v-dialog v-model="dialog" max-width="500px" persistent>
          <v-btn slot="activator" color="primary" dark class="mb-2">Nuevo</v-btn>
          <v-card>
            <v-card-title>
              <span class="headline">Nuevo Ingreso</span>
            </v-card-title>

            <v-card-text>
              <v-form ref="form">
                <v-text-field :rules="Placarules" v-model="placa" label="Placa" :counter='7'></v-text-field>
                <v-select v-model="tarifaId" :items="tarifas" :rules="[v => !!v || 'Escoga una Tarifa']" label="Tarifa"></v-select>
                <v-select v-model="cajeroId" :items="cajeros" :rules="[v => !!v || 'Escoga un Cajero']" label="Cajero"> </v-select>
                <v-select v-model="espacioId" :items="espacios"  :rules="[v => !!v || 'Escoga un Espacio']" label="Espacio"></v-select>
              </v-form>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click.native="guardar">Guardar</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
      <v-data-table :headers="headers" :items="ingresos" :search="search"  class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.espacio.espacioId }}</td>
          <td>{{ props.item.nombreCajero+"  "+ props.item.apellidoCajero }}</td>
          <td>{{ props.item.placa }}</td>
          <td>{{ time(props.item)}}</td>
          <td>{{ props.item.tarifa.tipoVehiculo }}</td>
          <td>{{ 'S/.'+props.item.tarifa.monto  }}</td>
        </template>
        <template slot="no-data">
          <span style="font-size:20px" >No hay ingresos</span>
        </template>
      </v-data-table>

      <!-- Actualizar  -->
      <v-dialog v-model="actualizar" max-width="500px">
          
          <v-card>
            <v-card-title>
              <span class="headline">Actualizar</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="placa" label="Placa"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-select v-model="tarifaId" :items="tarifas" label="Tarifa">
                    </v-select>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-select v-model="cajeroId" :items="cajeros" label="Cajero">
                    </v-select>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-select v-model="espacioId" :items="espacios" label="Espacio">
                    </v-select>
                  </v-flex>
                </v-layout>
              </v-container>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click.native="guardar">Guardar</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>

    </v-flex>
  </v-layout>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      ingresos:[],
      tarifas: [],
      cajeros:[],
      espacios:[],
      dialog: false,
      actualizar:false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
         { text: "Espacio", value: "espacioId",  sortable: false },
        { text: "Cajero", value: "cajero" ,  sortable: false},
        { text: "Placa", value: "placa",  sortable: false },
         { text: "H_Inicio", value: "h_inicio",  sortable: false },
         { text: "Tipo", value: "tipoVehiculo",sortable: false},
        { text: "Monto", value: "monto",sortable: false }
        
        
        
       
       
      ],
       Placarules: [
        v => !!v || 'Ingrese su placa',
        v => (v && v.length === 7 && /.+-.+/.test(v)) || 'Ingrese una placa válida',
        
        
      ],
      search: "",
      editedIndex: -1,
      
      //Model
      id: "",
      tarifaId: "",
      cajeroId: "", 
      placa: "",
      espacioId: ""
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Estacionamiento" : "Actualizar Estacionamiento";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },


  created() {
    this.listar();
   this.loadCajeros();
   this.loadTarifas();
   this.loadEspacios();
  },
  methods: {
    

    time(item){
      var fecha=new Date(item.hInicio);
      return fecha.getFullYear()+"-"+fecha.getMonth()+"-"+fecha.getDate()+" "+fecha.getHours()+":"
      +fecha.getMinutes();
    },

    listar() {
      let me = this;
      axios
        .get("api/Ingreso")
        .then(function(response) {
          //console.log(response);
          me.ingresos = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },

    loadCajeros(){
      let me =this;
       var aux=[];
      axios.get("api/Cajero").then(function(response){

          me.cajeros
          aux=response.data;
          aux.map((p)=>{
            me.cajeros.push({
              text:p.nombreCajero,
              value:p.id
            })
          });


      }).catch(function(error){
        console.log(error);
      })

    },
    loadTarifas(){
      let me =this;
      var aux=[];
        axios.get("api/Tarifa").then(function(response){
          aux=response.data;
          aux.map((t)=>{
            me.tarifas.push(
              {
                text:t.tipoVehiculo,
                value:t.tarifaId
              }
            )
          });
      }).catch(function(error){
        console.log(error);
      })


    },
    loadEspacios(){
       let me =this;
       var aux=[];
        axios.get("api/Espacio").then(function(response){
          aux=response.data;
          aux=aux.filter(function(item){
            return item.disponible==true;
          });
          aux.map((t)=>{
            me.espacios.push(
              {
                text:t.espacioId,
                value:t.espacioId
              }
            )
          });
         
      }).catch(function(error){
        console.log(error);
      })
    },



    
    editItem(item) {
      this.id=item.id;
      this.tarifa=item.tarifa;
      this.cajero=item.cajero;
      this.placa=item.placa;
  
      this.editedIndex = 1;
      this.dialog = true;
    },

  

    close() {
      this.dialog = false;
    },
    limpiar() {
      this.id= "",
      this.tarifaId= "",
      this.cajeroId= "", 
      this.placa= "",
      this.espacioId= ""
    },
    guardar() {
      if (this.$refs.form.validate()) {
        //Código para guardar
        let me = this;
        axios
          .post("api/Ingreso", {
            tarifaId: me.tarifaId,
            cajeroId: me.cajeroId,
            placa: me.placa,
            espacioId:me.espacioId,
          })
          .then(function(response) {
            this.$refs.form.reset();
            me.close();
            me.listar();
            this.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
          }
          
      
    }
  }
};
</script>
