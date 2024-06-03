<template>
	<v-container class="text-center">
		<v-card class="mx-auto" max-width="800" outlined>
			<v-card-title class="text-h5" >Word List Editor</v-card-title>
            <v-card-text>
                To delete a word, locate or search for it in the list at the bottom and click it<br />
                To add a word, enter it in the box below <br />
                To switch between all of the 5 letter words or just the common ones, hit the buttons below
            </v-card-text>
            <v-container>
                <v-btn color="primary" variant="flat" @click="useNormalWords(1)">Use All Words</v-btn>
                <v-btn color="primary" variant="flat" @click="useNormalWords(0)">Use Common Words</v-btn>
            </v-container>
            <v-container>
                <p>New Word: {{ newWord }}</p>
                <input v-model="newWord" placeholder="Enter new word here" />
                <p>{{ newWordError }}</p>
                <v-btn color="primary" variant="flat" @click="addNewWord(newWord)">Confirm</v-btn>
            </v-container>
            <v-autocomplete
                v-model="curWord"
                prepend-inner-icon="mdi-magnify"
                :items="validWords()"
                placeholder="Enter a Word!"
                @update:modelValue="updatePage(curWord)"
            />
            <v-btn
                height="40px"
                class="align-center d-flex justify-center"
                v-for="word in pagedWords"
                :key="word"
                @click="removeWord(word)"
                >
                {{ word.toUpperCase() }}
            </v-btn>
            <v-card-item class="ma-3">
                <v-pagination
                    density="compact"
                    v-model="currentPage"
                    :length="totalPages"
                    total-visible="10"
                />
            </v-card-item>
        	<v-card-actions>
				<v-spacer></v-spacer>
				<v-btn color="primary" variant="flat" @click="router.push('/')">Home</v-btn>
			</v-card-actions>
		</v-card>
		
	</v-container>
</template>

<script setup lang="ts">
  import { WordList } from "~/scripts/wordList";
  import { commonWordList } from "~/scripts/commonWordList";
  import { Game } from "~/scripts/game";
  import { updateValidWords } from "~/scripts/wordListUtils";
  const game: Game = inject("GAME")!;
  const curWord = ref("");
  var newWord = ref("");
  var newWordError = "";
  const router = useRouter();
  const modelValue = defineModel<boolean>({ default: false });
  var words = WordList;
  const totalPages = ref(Math.ceil(words.length / 10));
  const updatedWords = ref(words);
  const currentPage = ref(1);
  const pagedWords = computed(() => {
    const start = (currentPage.value - 1) * 10;
    return validWords().slice(
      start,
      start+10
    );
  });
  
  function validWords(): string[] {
    return words;
  }

  function removeWord(word:string){
    const index = words.indexOf(word, 0);
    if (index > -1) {
        words.splice(index, 1);
    }
  }

  function updatePage(word:string){
    const index = words.indexOf(word.toLowerCase());
    if (index !== -1) {
        const pageNumber = Math.ceil((index + 1) / 10);
        currentPage.value = pageNumber;
    }
  }

  function addNewWord(word:string){
    if(word.length!=5){
        newWordError = "Error, word must be 5 letters";
    }
    else if(words.indexOf(word) != -1){
        newWordError = "Error, word already in list";
    }
    else{
        newWordError = "";
        words.push(word.trim().toLowerCase());
        words.sort();
    }
  }

  function useNormalWords(yes: number){
    if(yes == 1){
        words = WordList;
    }
    else{
        words = commonWordList;
    }
  }

</script>
