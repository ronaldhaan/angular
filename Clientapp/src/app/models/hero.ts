class Abilities {
    id: number;
    name: string;
    description: string;
}

/** represents a hero. */
export class Hero {
    id: number;
    name: string;
    abilities: Abilities[];
}