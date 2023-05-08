export class Person implements Serializable<Person>
{
    constructor(
        public id: number,
        public firstName: string,
        public lastName: string,
        public dateOfBirth: string,
        public email: string,
        public phone: string
    ) {
    }

    deserialize(input: any): Person {
        this.id = input.id;
        this.firstName = input.firstName;
        this.lastName = input.lastName;
        this.dateOfBirth = input.dateOfBirth;
        this.email = input.email;
        this.phone = input.phone;
        return this;
    }
}

interface Serializable<T> {
    deserialize(input: any): T;
}