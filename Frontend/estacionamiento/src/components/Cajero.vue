<template>
  <v-layout align-start>
    <v-flex>
      <!--<v-alert v-model="alert" dismissible type="success">Se ha actualizado correctamente</v-alert>-->
      <!--<v-alert v-model="error" dismissible type="error">No se pudo actualizado correctamente</v-alert>-->
      <v-toolbar flat color="white">
        <v-toolbar-title>Cajeros</v-toolbar-title>
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
        <v-dialog v-model="dialog" max-width="500px">
          <v-btn slot="activator" color="primary" dark class="mb-2">Nuevo</v-btn>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="nombreCajero" label="Nombre"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="apellidoCajero" label="Apellido"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="fechaIngreso" label="Fecha Ingreso"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-select v-model="turnoCajero" :items="metodosCajero" label="Turno">
                    </v-select>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-select v-model="puntoAtencionId" :items="puntos" label="Punto de Atencion">
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
      </v-toolbar>
      <v-data-table :headers="headers" :items="cajeros" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
            <!--<v-icon small class="mr-2" @click="deleteItem(props.item.id)">delete</v-icon>-->
          
          </td>
          <td>{{ props.item.nombreCajero }}</td>
          <td>{{ props.item.apellidoCajero }}</td>
          <td>{{ props.item.fechaIngreso }}</td>
          <td>{{ props.item.turnoCajero }}</td>
          <td>{{ props.item.puntoAtencionId }}</td>
        </template>
        <template slot="no-data">
          <v-btn color="primary" @click="listar">Resetear</v-btn>
        </template>
      </v-data-table>
    </v-flex>
  </v-layout>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      cajeros: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Nombre", value: "nombreCajero", sortable: false },
        { text: "Apellido", value: "apellidoCajero", sortable: false },
        { text: "FechaIngreso", value: "fechaIngreso" },
        { text: "TurnoCajero", value: "turnoCajero" },
        { text: "PuntoAtencion", value: "puntoAtencionId" }
      ],
      search: "",
      editedIndex: -1,

      puntos: [],

      //Model
      id: "",
      nombreCajero: '',
      apellidoCajero: '',
      fechaIngreso: '',
      turnoCajero: '',
      metodosCajero: ['Mañana', 'Tarde', 'Noche'],
      puntoAtencionId: ''
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Cajero" : "Actualizar Cajero";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
    this.listar();
    this.listarPuntoAtencion();
  },
  methods: {
    listar() {
      let me = this;
      axios
        .get("api/cajero")
        .then(function(response) {
          //console.log(response);
          me.cajeros = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },

    listarPuntoAtencion() {
            let me = this;
            var puntoArray = [];
            axios.get('api/puntoAtencion').then(function (response) {
                // console.log(response.data);
                puntoArray = response.data;
                puntoArray.map((p) => {
                    me.puntos.push({
                        text: p.ubicacion,
                        value: p.id
                    });
                });
            }).catch(function (error) {
                console.log(error);
            });
        },

    
     editItem(item) {
       this.id = item.id;
       this.nombreCajero = item.nombreCajero;
       this.apellidoCajero = item.apellidoCajero;
       this.fechaIngreso = item.fechaIngreso;
       this.turnoCajero = item.turnoCajero;
       this.puntoAtencionId = item.puntoAtencionId;

       this.editedIndex = 1;
       this.dialog = true;
     },

    // deleteItem(item){
    //   this.id=item.id;
    // },

    close() {
      this.dialog = false;
    },
    limpiar() {
      this.id = "";
      this.nombreCajero = "";
      this.apellidoCajero = "";
      this.fechaIngreso = "";
      this.turnoCajero = "";
      this.puntoAtencionId = "";
    },
    guardar() {
      if (this.editedIndex > -1) {
        //Código para editar

         let me = this;
         axios 
           .put("api/cajero", {
            id: me.id,
            nombreCajero: me.nombreCajero,
            apellidoCajero: me.apellidoCajero,
            fechaIngreso: me.fechaIngreso,
            turnoCajero: me.turnoCajero,
            puntoAtencionId: me.puntoAtencionId
           })
           .then(function(response) {
             me.close();
             me.listar();
             me.limpiar();
             //me.alert=true;
           })
           .catch(function(error) {
             console.log(error);
             //me.error=true;
           });
      } else {
        //Código para guardar
        let me = this;
        axios
          .post("api/cajero", {
            nombreCajero: me.nombreCajero,
            apellidoCajero: me.apellidoCajero,
            fechaIngreso: me.fechaIngreso,
            turnoCajero: me.turnoCajero,
            puntoAtencionId: me.puntoAtencionId
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
            //me.alert=true;
          })
          .catch(function(error) {
            console.log(error);
            //me.error=true;
          });
      }
    },
    // delete() {
    //      let me = this;
    //      axios 
    //        .delete("api/cajero"+me.id ,{
    //          id: me.id
    //        })
    //        .then(function(response) {
    //          me.listar();
    //          //me.alert=true;
    //        })
    //        .catch(function(error) {
    //          console.log(error);
    //          //me.error=true;
    //        });
    // }
  }
};
</script> 
