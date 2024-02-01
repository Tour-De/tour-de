import { Serializable } from "@util/iserializable";

export class Person implements Serializable<Person> {
  constructor(
    public id: number,
    public firstName: string,
    public lastName: string,
    public email: string,
    public phone?: string,
    public dateOfBirth?: string
  ) {}

  deserialize(input: any): Person {
    this.id = input.id;
    this.firstName = input.firstName;
    this.lastName = input.lastName;
    this.email = input.email;
    this.phone = input.phone;
    this.dateOfBirth = input.dateOfBirth;
    return this;
  }
}

