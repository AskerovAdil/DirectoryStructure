<template>
    <div class="post">

        <details    
            class="border-l hover:cursor-pointer transition-all ease-in gap-2 border-s-[2px] border-blue-500 bg-blue-50 px-4 py-3 text-blue-700">
            <summary class="card-header">
                <h2 class="flex justify-between">
                    <span class="btn btn-link">
                        Id: {{ catalog.id }}
                        Name: {{ catalog.name }}
                    </span>
                </h2>
            </summary>
            <ul>
                <div>

                    <div v-for="el in catalog.subCatalogs" :key="el.id">
                        <NodeDirectory :catalog="el"></NodeDirectory>
                    </div>

                </div>
            </ul>
        </details>
    </div>
</template>

<script lang="js">
import { defineComponent } from 'vue';
import NodeDirectory from './DirectoryStructure.vue';

export default defineComponent({

    components: {
        NodeDirectory
    },
    props: {
        catalog: Array,
    }

});
</script>

