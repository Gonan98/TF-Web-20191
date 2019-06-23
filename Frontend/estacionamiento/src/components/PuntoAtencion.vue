<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>PuntoAtencion</v-toolbar-title>
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
                    <v-text-field v-model="ubicacion" label="Ubicacion"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-combobox v-model="cajeros" :items = "cajeross" label="Cajeros"></v-combobox>
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
      <v-data-table :headers="headers" :items="puntosatencion" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-1" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.ubicacion}} </td>
          <td>{{ props.item.cajeros}}</td>
        </template>
        <template slot="no-data">
          <v-btn color="dark" @click="listar">Resetear</v-btn>
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
      puntosatencion: [],

      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: " Ubicacion", value: "ubicacion", sortable: false },
        { text: " Cajero", value: "cajeros"},
      ],
      search: "",
      editedIndex: -1,

        cajeross: [],
      //Model
      id: "",
      ubicacion: "",
      cajeros: "",
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo PuntoAtencion" : "Actualizar PuntoAtencion";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
    this.listar();
    this.listarCajeros();
  },
  methods: {
    listar() {
      let me = this;
      axios
        .get("api/PuntoAtencion")
        .then(function(response) {
          //console.log(response);
          me.puntosatencion = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
  listarCajeros(){
      let me = this;
      var cajeroArray = [];
      axios.get('api/cajero').then(function(response){
        cajeroArray = response.data;
        cajeroArray.map((c)=>{
          me.cajeross.push({
              text: c.nombreCajero,
              value: c.id

          });

        });

      }).catch(function(error){
          console.log(error);
      });
  },
    editItem(item) {
      this.id = item.id;
      this.ubicacion = item.ubicacion;
      this.editedIndex = 1;
      this.dialog = true;
      this.cajeros = item.cajeros;
    },

    close() {
      this.dialog = false;
    },
    limpiar() {
      this.id = "";
    },
    
    deletePunto() {
      axios.get('api/PuntoAtencion').then(function(response){
        this.puntosatencion.splice(id, 1);
      });
    
  },
   guardar() {
      if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/PuntoAtencion", {
            id: me.id,
            ubicacion: me.ubicacion,
            cajeros: me.cajeros
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      } else {
        //Código para guardar
        let me = this;
        axios
          .post("api/PuntoAtencion", {
            ubicacion: me.ubicacion
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      }
    }
    
  }
};
</script>