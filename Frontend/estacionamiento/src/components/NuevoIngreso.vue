<template>
    <v-dialog :value="open" max-width="500px" persistent>
          <v-card>
            <v-card-title>
              <span class="headline">Nuevo Ingreso</span>
            </v-card-title>

            <v-card-text>
              <v-form ref="form">
                <v-text-field :rules="Placarules" v-model="placa" label="Placa" :counter='7'></v-text-field>
                <v-select v-model="tarifaId" :items="tarifas" :rules="[v => !!v || 'Escoga una Tarifa']" label="Tarifa"></v-select>
              </v-form>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1"  flat @click.native="guardar">Guardar</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
</template>
<script>
import axios from "axios";
export default {
    props:['dialog','cajero','espacio'],
    data() {
        return {
            open:true,
            tarifas:[],
            placa:"",
            tarifaId:"",
            Placarules: [
        v => !!v || 'Ingrese su placa',
        v => (v && v.length === 7 && /.+-.+/.test(v)) || 'Ingrese una placa válida',
        
        
        ],
        }
    },
    created() {
        
        this.loadTarifas();
    },
    methods: {
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

    close() {
      this.open = false;
    },
    guardar() {
      if (this.$refs.form.validate()) {
        //Código para guardar
        let me = this;
        axios
          .post("api/Ingreso", {
            tarifaId: me.tarifaId,
            cajeroId: me.cajero.id,
            placa: me.placa,
            espacioId:me.espacio,
          })
          .then(function(response) {
              if (response.data==false) {
                  alert("Ya hay un ingreso con esa placa");
              }
            
          })
          .catch(function(error) {
            console.log(error);
          });
         me.$refs.form.reset();
            
            this.$emit('fin',true);
            this.close();
          }
          
          
      
    }

    },
      
}
</script>
