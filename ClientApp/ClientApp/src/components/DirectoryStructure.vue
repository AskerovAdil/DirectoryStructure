<template>
    <div class="post">
        <CreateNode></CreateNode>
        <div v-for="el in post" :key="el.id">
            <NodeDirectory :catalog="el"></NodeDirectory>
        </div>
    </div>
</template>

<script lang="js">
import { defineComponent } from 'vue';
import NodeDirectory from './NodeDirectory.vue';
import CreateNode from './CreateNode.vue';
export default defineComponent({
        components: { NodeDirectory, CreateNode },
        data() {
            return {
                loading: false,
                post: null,
                AddVue: false
            };
        },
        created() {
            this.fetchData();
        },
        watch: {
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.post = null;
                this.loading = true;

                fetch('api/Catalog')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json;
                        this.loading = false;
                        return;
                    });
            }
        },
});
</script>

<style>
    details summary::-webkit-details-marker {
        display: none
    }

    details > summary {
        list-style: none;
    }

    html {
        position: relative;
        min-height: 100%;
    }

    body {
        margin-bottom: 60px;
        padding: 2rem 5rem;
    }
</style>