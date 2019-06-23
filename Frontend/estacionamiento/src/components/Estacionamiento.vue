<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Estacionamientos</v-toolbar-title>
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
                    <v-text-field v-model="nombre_Estacionamiento" label="nombre_Estacionamiento"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="numero_Espacios" label="numero_Espacios"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="direccion" label="direccion"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="localizacionId" label="Localizacion"></v-text-field>
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
      <v-data-table :headers="headers" :items="estacionamientos" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.nombre_Estacionamiento }}</td>
          <td>{{ props.item.numero_Espacios }}</td>
          <td>{{ props.item.direccion }}</td>
          <td>{{ props.item.localizacionId }}</td>
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
      estacionamientos: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "nombre_Estacionamiento", value: "nombre_Estacionamiento", sortable: false },
        { text: "numero_Espacios", value: "numero_Espacios", sortable: false },
        { text: "direccion", value: "direccion" },
        { text: "localizacionId", value: "localizacionId" }
      ],
      search: "",
      editedIndex: -1,

      //Model
      id: "",
      nombre_Estacionamiento: "",
      numero_Espacios: "", 
      direccion: "",
      localizacionId: ""
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
  },
  methods: {
    listar() {
      let me = this;
      axios
        .get("api/Estacionamiento")
        .then(function(response) {
          //console.log(response);
          me.estacionamientos = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },



    
    editItem(item) {
      this.id = item.id;
      this.nombre_Estacionamiento=item.nombre_Estacionamiento;
      this.numero_Espacios=item.numero_Espacios;
      this.direccion=item.direccion;
      this.localizacionId=item.localizacionId;
  
      this.editedIndex = 1;
      this.dialog = true;
    },

  

    close() {
      this.dialog = false;
    },
    limpiar() {
      this.id = "";
      this.nombre_Estacionamiento= "";
      this.numero_Espacios= "";
      this.direccion= "";
      this.localizacionId= "";
    },
    guardar() {
      if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/Estacionamiento", {
            id: me.id,
            nombre_Estacionamiento: me.nombre_Estacionamiento,
            numero_Espacios: me.numero_Espacios,
            direccion: me.direccion,
            localizacionId:me.localizacionId
    
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
          .post("api/Estacionamiento", {
            nombre_Estacionamiento: me.nombre_Estacionamiento,
            numero_Espacios: me.numero_Espacios,
            direccion: me.direccion,
            localizacionId:me.localizacionId
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
