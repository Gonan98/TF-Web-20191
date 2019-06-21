<template>
  <v-layout align-start>
    <v-flex>
      <!--<v-alert v-model="alert" dismissible type="success">Se ha actualizado correctamente</v-alert>-->
      <!--<v-alert v-model="error" dismissible type="error">No se pudo actualizado correctamente</v-alert>-->
      <v-toolbar flat color="white">
        <v-toolbar-title>Comprobantes</v-toolbar-title>
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
                    <v-select v-model="ingresoId" :items="ingresos" label="Placa Ingreso">
                    </v-select>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="horaFin" label="Hora final"></v-text-field>
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
      <v-data-table :headers="headers" :items="comprobantes" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
            <!--<v-icon small class="mr-2" @click="deleteItem(props.item.id)">delete</v-icon>-->
          
          </td>
          <td>{{ props.item.ingresoId }}</td>
          <td>{{ props.item.placa }}</td>
          <td>{{ props.item.hInicio }}</td>
          <td>{{ props.item.horaFin }}</td>
          <td>{{ props.item.monto }}</td>
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
      comprobantes: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Ingreso", value: "ingresoId" },
        { text: "Placa", value: "placa", sortable: false },
        { text: "HoraInicio", value: "hInicio" },
        { text: "HoraFin", value: "horaFin" },
        { text: "Monto", value: "monto" }
      ],
      search: "",
      editedIndex: -1,

      ingresos: [],

      //Model
      id: "",
      placa: '',
      hInicio: '',
      horaFin: '',
      monton: 0.,
      ingresoId: ''
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Comprobante" : "Actualizar Comprobante";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
    this.listar();
    this.listarIngresos();
  },
  methods: {
    listar() {
      let me = this;
      axios
        .get("api/comprobante")
        .then(function(response) {
          //console.log(response);
          me.comprobantes = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },

    listarIngresos() {
            let me = this;
            var ingresoArray = [];
            axios.get('api/ingreso').then(function (response) {
                // console.log(response.data);
                ingresoArray = response.data;
                ingresoArray.map((p) => {
                    me.ingresos.push({
                        text:p.placa,
                        value: p.id
                    });
                });
            }).catch(function (error) {
                console.log(error);
            });
        },

    
      editItem(item) {
        this.id = item.id;
        this.horaFin=item.horaFin;
        this.ingresoId=item.ingresoId;

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
      this.ingresoId = "";
      this.placa = "";
      this.hInicio = "";
      this.horaFin = "";
      this.monto = 0.;
    },
    guardar() {
        if (this.editedIndex > -1) {
        //Código para editar

         let me = this;
         axios 
           .put("api/comprobante", {
            id: me.id,
            horaFin: me.horaFin,
            ingresoId: me.ingresoId
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
        let me = this;
            axios
            .post("api/comprobante", {
                ingresoId: me.ingresoId,
                horaFin: me.horaFin,
                monto: me.monto
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
};
</script> 
