# JSON Test
 To serialize/deserialized specific class to/from JSON
 
 I've been working on an Unity app that serializes and deserializes answers to multiple items. The app has been thus far saving a class that is a lists of each item answered. Thus I have to deserialize multiple lists add respective items to each list, then (re)serialize all these lists.
 
 I suspected I had done this "wrong" -- ineffeciently or sloppily.
 
I set this up to see if I could make a more efficient system of creating a class (even with multiple constructs) and then nest it that class in a list class in order to serialize the list as a JSON file. It certainly works.

Now I have this as a reference for a system of serializing/deserializing nested classes.
I can now also apply this to the app that I was working on.
