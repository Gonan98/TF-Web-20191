<template>
  <v-app id="app">
    <v-navigation-drawer
      fixed
      :clipped="$vuetify.breakpoint.mdAndUp"
      app
      v-model="drawer"
    >
      <v-list dense>
        <template>
          <v-list-tile :to="{name:'home'}">
            <v-list-tile-action>
              <v-icon>home</v-icon>
            </v-list-tile-action>
            <v-list-tile-title>
              Inicio
            </v-list-tile-title>
          </v-list-tile>
        </template>

        <template>
          <v-list-group>
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                  Mantenimiento
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'tarifas'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Tarifas
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'espacios'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Espacios
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'estacionamientos'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Estacionamiento
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'localizaciones'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Localizacion
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'cajeros'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Cajero
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'punto_atenciones'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Punto de Atencion
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'ingresos'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Ingreso
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'comprobantes'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Comprobante
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

          </v-list-group>
        </template>
        
       
        
      </v-list>
    </v-navigation-drawer>
    <v-toolbar
      color="blue darken-3"
      dark
      app
      :clipped-left="$vuetify.breakpoint.mdAndUp"
      fixed
    >
      <v-toolbar-title style="width: 300px" class="ml-0 pl-3">
        <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
        <span class="hidden-sm-and-down">EstacionamientoApp</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn icon>
        <v-icon>apps</v-icon>
      </v-btn>
    </v-toolbar>
    <v-content>
      <v-container fluid fill-height>
        <v-slide-y-transition mode="out-in">
          <router-view/>
        </v-slide-y-transition>
      </v-container>
    </v-content>
    <v-footer dark height="auto">
      <v-layout justify-center>
        <v-flex text-xs-center>
          <v-card flat tile color="secondary" class="white--text">
            <v-card-text class="white--text pt-0">
             TF-Aplicaciones-Web &copy;2019
            </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
    </v-footer>

  </v-app>
</template>


<script>

export default {
  name: 'App',
  data () {
    return {
      drawer: true,
     }
  }
}
</script>
