<template>
    <div class=" mb-2">
        <span @click="AddVue = !AddVue" class="inline-flex overflow-hidden rounded-md border bg-white shadow-sm">
            <a v-if="!AddVue" class="inline-block border-e p-3 text-gray-700 hover:bg-gray-50 focus:relative"
                title="Edit Product">
                Добавить каталог
            </a>
        </span>
        <form v-if="AddVue" @submit="onSubmit()" class="bg-blue-50 shadow-sm rounded-md p-3 my-2 ">
                <div class="text-center my-4">Добавить каталог</div>
            <span class="overflow-hidden rounded-md border bg-white shadow-sm">
                <input v-model="post.name" class="mb-2 w-full rounded-lg border-gray-200 p-3 text-sm" placeholder="Name"
                    type="text" id="name" />
                <input v-model="post.parentId" class="w-full rounded-lg border-gray-200 p-3 text-sm" placeholder="ParenId"
                    type="text" id="name" />
            </span>
            <span class="mt-4 inline-flex overflow-hidden rounded-md border bg-white shadow-sm">
                <button type="submit" v-if="AddVue"
                    class="inline-block border-e p-3 text-gray-700 hover:bg-gray-50 focus:relative" title="Edit Product">
                    Сохранить
                </button>
            </span>
        </form>
    </div>
</template>

<script>
export default {
    data() {
        return {
            post: {},
            AddVue: false
        };
    },
    methods: {
        async onSubmit() {
            console.log("asdsadas")
            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");

            var raw = JSON.stringify(this.post);

            var requestOptions = {
                method: 'POST',
                headers: myHeaders,
                body: raw,
                redirect: 'follow'
            };

            await fetch("api/Catalog", requestOptions)
                .then(response => response.json())
                .then(() => this.$emit("CreatedNode"))
                .catch(error => console.log('error', error));
            this.AddVue = !this.AddVue;
        }
    },
}
</script>

<style lang="scss" scoped></style>